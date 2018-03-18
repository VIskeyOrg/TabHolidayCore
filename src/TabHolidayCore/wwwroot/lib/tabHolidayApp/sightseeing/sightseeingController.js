myapp.controller('SightSeeingController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.ViewMode = "list";
    $scope.IsEditMode = false;    

    $scope.InitializeObject = function () {
        $scope.SightSeeing = {};
        $scope.SightSeeing.TimeSlots = [];
        $scope.SightSeeing.Inclusions = [];
        $scope.SightSeeing.BlackOuts = [];

        //if ($scope.SightSeeing.TimeSlots < 1) {
        //    $scope.AddTimeSlot();
        //}
        //if ($scope.SightSeeing.Inclusions.length < 1) {
        //    $scope.AddInclusion();
        //}

        //if ($scope.SightSeeing.BlackOuts.length < 1) {
        //    $scope.AddBlackOut();
        //}
    };

    $scope.NewSightSeeing = function () {
        $scope.ViewMode = "new";
        $scope.IsEditMode = false;
        $scope.InitializeObject();
    };

    $scope.LoadData = function () {
        $scope.Hours = [];
        for (i = 0; i <= 24; i++) {
            $scope.Hours.push(i);
        }
        $scope.InitializeObject();
        $scope.StarRatings = myappService.GetStarRatings();
        $scope.SightSeeingCategories = myappService.GetSightSeeingCategories();
        $scope.InclusionTypes = myappService.GetInclusionTypes();
        $scope.GetSightSeeings();
    };

    $scope.GetSightSeeings = function () {
        $http.get('/SightSeeing').then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {
                    $scope.SightSeeings = successResponse.data.ChangedData;
                }
                else {
                    alert(successResponse.data.Message);
                }
            },
              function (errorResponse) {

              });
    };

    $scope.AddTimeSlot = function () {
        var IsEmpty = false;
        angular.forEach($scope.SightSeeing.TimeSlots, function (val) {
            if (!val.IsDelete)
            {
                if (val.StartTime == "", val.EndTime == "") {
                    IsEmpty = true;
                }
            }
            
        });
        if (!IsEmpty) {
            $scope.SightSeeing.TimeSlots.push({ StartTime: "", EndTime: "" });
        }
        else {
            alert("Please fill empty field first");
        }
    };

    $scope.RemoveTimeSlot = function (TimeSlot) {
        if (!$scope.IsEditMode)
        {
            var index = $scope.SightSeeing.TimeSlots.indexOf(TimeSlot);
            $scope.SightSeeing.TimeSlots.splice(index, 1);
        }
        else {
            TimeSlot.IsDelete = true;
        }
        
    };

    $scope.AddInclusion = function () {

        var InclusionStr = { InclusionStr: "" };
        var Inclusion = { InclusionTypeId: "", Duration: "", InclusionArray: [] }
        Inclusion.InclusionArray.push(InclusionStr);
        $scope.SightSeeing.Inclusions.push(Inclusion);
    };

    $scope.RemoveInclusion = function (Inclusion) {
        if (!$scope.IsEditMode) {
            var index = $scope.SightSeeing.Inclusions.indexOf(Inclusion);
            $scope.SightSeeing.Inclusions.splice(index, 1);
        }
        else {
            Inclusion.IsDelete = true;
        }
        
    };

    $scope.AddInclusionStr = function (Inclusion) {
        var InclusionStr = { InclusionStr: "" };
        Inclusion.InclusionArray.push(InclusionStr);
    };

    $scope.RemoveInclusionStr = function (Inclusion, InclusionStr) {
        var index = Inclusion.InclusionArray.indexOf(InclusionStr);
        Inclusion.InclusionArray.splice(index, 1);
    };

    $scope.AddBlackOut = function () {

        var blackOut = {};
        $scope.SightSeeing.BlackOuts.push(blackOut);
    };

    $scope.RemoveBlackOut = function (BlackOut) {
        if (!$scope.IsEditMode) {
            var index = $scope.SightSeeing.BlackOuts.indexOf(BlackOut);
            $scope.SightSeeing.BlackOuts.splice(index, 1);
        }
        else {
            BlackOut.IsDelete = true;
        }
    };

    $scope.Save = function () {

        angular.forEach($scope.SightSeeing.Inclusions, function (Inclusion) {

            angular.forEach(Inclusion.InclusionArray, function (InclusionStr, Index) {
                if (Index == 0) {
                    Inclusion.Inclusions = InclusionStr.InclusionStr;
                }
                else {
                    Inclusion.Inclusions = Inclusion.Inclusions + "|" + InclusionStr.InclusionStr;
                }

            });
        });

        angular.forEach($scope.SightSeeing.TimeSlots, function (TimeSlot) {
            try{
                TimeSlot.StartHour = TimeSlot.StartTime.getHours();
                TimeSlot.StartMinute = TimeSlot.StartTime.getMinutes();

                TimeSlot.EndHour = TimeSlot.EndTime.getHours();
                TimeSlot.EndMinute = TimeSlot.EndTime.getMinutes();
            }
            catch(err){

            }
            
        });


        if (!$scope.IsEditMode) {
            $http.post('/SightSeeing/Add', $scope.SightSeeing).then(
                function (successResponse) {
                    if (successResponse.data.isSuccess) {

                        //$scope.InitializeObject();
                        alert(successResponse.data.Message);

                    }
                    else {

                        alert(successResponse.data.Message);

                    }
                },
                 function (errorResponse) {

                 });
        }
        else
        {

            $http.post('/SightSeeing/Edit', $scope.SightSeeing).then(
                function (successResponse) {
                    if (successResponse.data.isSuccess) {

                        //$scope.InitializeObject();
                        alert(successResponse.data.Message);

                    }
                    else {

                        alert(successResponse.data.Message);

                    }
                },
                 function (errorResponse) {

                 });

        }



    };

    $scope.CancelForm = function () {
        $scope.SightSeeing = {};
        $scope.ViewMode = "list";
    };

    $scope.EditSightSeeing = function (SightSeeing) {
        $scope.IsEditMode = true;
        $scope.ViewMode = "new";
        $scope.SightSeeing = SightSeeing;
        $scope.SightSeeing.SightSeeingCategoryId = SightSeeing.SightSeeingCategoryId.toString();
        $scope.SightSeeing.StarRatingId = SightSeeing.StarRatingId.toString();
        $scope.SightSeeing.DurationHour = SightSeeing.DurationHour.toString();
        $scope.SightSeeing.DurationMinute = SightSeeing.DurationMinute.toString();

        angular.forEach($scope.SightSeeing.Inclusions, function (Inclusion) {
            Inclusion.InclusionTypeId = Inclusion.InclusionTypeId.toString();
            Inclusion.DurationHour = Inclusion.DurationHour.toString();
            Inclusion.DurationMinute = Inclusion.DurationMinute.toString();
            Inclusion.InclusionArray = [];
            var InclusionStringArray = Inclusion.Inclusions.split('|');

            angular.forEach(InclusionStringArray, function (InclusionString) {
                Inclusion.InclusionArray.push({ InclusionStr: InclusionString });
            });
        });


        angular.forEach($scope.SightSeeing.TimeSlots, function (TimeSlot) {
            TimeSlot.StartTime = new Date();
            TimeSlot.StartTime.setHours(TimeSlot.StartHour);
            TimeSlot.StartTime.setMinutes(TimeSlot.StartMinute);
            TimeSlot.StartTime.setMilliseconds(0);
            TimeSlot.StartTime.setSeconds(0);

            TimeSlot.EndTime = new Date();
            TimeSlot.EndTime.setHours(TimeSlot.EndHour);
            TimeSlot.EndTime.setMinutes(TimeSlot.EndMinute);
            TimeSlot.EndTime.setMilliseconds(0);
            TimeSlot.EndTime.setSeconds(0);
        });

        angular.forEach($scope.SightSeeing.BlackOuts, function (BlackOut) {
            BlackOut.BlackOutStartDate = new Date(BlackOut.BlackOutStartDate);
            BlackOut.BlackOutEndDate = new Date(BlackOut.BlackOutEndDate);


        });

    };

    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });

}]);