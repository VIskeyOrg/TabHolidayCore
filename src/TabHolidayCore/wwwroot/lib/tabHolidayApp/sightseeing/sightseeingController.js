myapp.controller('SightSeeingController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.SightSeeing = {};
    $scope.SightSeeing.TimeSlots = [];
    $scope.SightSeeing.Inclusions = [];
    $scope.SightSeeing.AllInclusions = [];


    $scope.LoadData = function () {
        $scope.StarRatings = myappService.GetStarRatings();
        $scope.SightSeeingCategories = myappService.GetSightSeeingCategories();
        $scope.InclusionTypes = myappService.GetInclusionTypes();

        if ($scope.SightSeeing.TimeSlots < 1) {
            $scope.AddTimeSlot();
        }
        if ($scope.SightSeeing.Inclusions.length < 1) {
            $scope.AddInclusion();
        }


    };

    $scope.AddTimeSlot = function () {
        var IsEmpty = false;
        angular.forEach($scope.SightSeeing.TimeSlots, function (val) {
            if (val.StartTime == "", val.EndTime == "") {
                IsEmpty = true;
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
        var index = $scope.SightSeeing.TimeSlots.indexOf({ StartTime: "", EndTime: "" });
        $scope.SightSeeing.TimeSlots.splice(index, 1);
    };

    $scope.AddInclusion = function () {

        var InclusionStr = { InclusionStr: "" };
        var Inclusion = { InclusionTypeId: "", Duration: "", InclusionArray: [] }
        Inclusion.InclusionArray.push(InclusionStr);
        $scope.SightSeeing.Inclusions.push(Inclusion);
    };

    $scope.RemoveInclusion = function (Inclusion) {
        var index = $scope.SightSeeing.Inclusions.indexOf(Inclusion);
        $scope.SightSeeing.Inclusions.splice(index, 1);
    };

    $scope.AddInclusionStr = function (Inclusion) {
        var InclusionStr = { InclusionStr: "" };
        Inclusion.InclusionArray.push(InclusionStr);
    };

    $scope.RemoveInclusionStr = function (Inclusion, InclusionStr) {
        var index = Inclusion.InclusionArray.indexOf(InclusionStr);
        Inclusion.InclusionArray.splice(index, 1);
    };

    $scope.Save = function () {

        angular.forEach($scope.SightSeeing.Inclusions, function (Inclusion) {
            Inclusion.DurationHour = Inclusion.Duration.getHours();
            Inclusion.DurationMinute = Inclusion.Duration.getMinutes();
        });

        angular.forEach($scope.SightSeeing.TimeSlots, function (TimeSlot) {
            TimeSlot.StartHour = TimeSlot.StartTime.getHours();
            TimeSlot.StartMinute = TimeSlot.StartTime.getMinutes();

            TimeSlot.EndHour = TimeSlot.EndTime.getHours();
            TimeSlot.EndMinute = TimeSlot.EndTime.getMinutes();
        });

        $http.post('/SightSeeing/Add', $scope.SightSeeing).then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {

                    $scope.SightSeeing = {};
                    alert(successResponse.data.Message);

                }
                else {

                    alert(successResponse.data.Message);

                }
            },
              function (errorResponse) {

              });

    };


    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });

}]);