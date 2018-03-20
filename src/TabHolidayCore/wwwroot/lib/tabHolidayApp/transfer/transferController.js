myapp.controller('TransferController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.ViewMode = "list";

        


    $scope.InitializeObject = function () {
            $scope.Transfer = {};
            $scope.Transfer.TimeSlots = [];
            $scope.Transfer.BlackOuts = [];
            $scope.Transfer.VehicleTypes = [];
            $scope.Transfer.PremiumDates = [];

            if ($scope.Transfer.TimeSlots < 1) {
                $scope.AddTimeSlot();
            }

            if ($scope.Transfer.BlackOuts < 1) {
                $scope.AddBlackOut();
            }

            if ($scope.Transfer.VehicleTypes < 1) {
                $scope.AddVehicleType();
            }

            if ($scope.Transfer.PremiumDates < 1) {
                $scope.AddPremiumDate();
            }
        };
    
    $scope.NewTransfer = function () {
            $scope.InitializeObject();
            $scope.ViewMode = "new";
            $scope.IsEditMode = false;
        };

    $scope.LoadData = function () {

        $scope.Hours = [];
        for (i = 0; i <= 24; i++) {
            $scope.Hours.push(i);
        }

            $scope.TransferTypes = myappService.GetTransferTypes();
            $scope.TransferCategories = myappService.GetTransferCategories();
            $scope.GetAllTransfers();
          };  

    $scope.AddTimeSlot = function () {
        var IsEmpty = false;
        angular.forEach($scope.Transfer.TimeSlots, function (val) {
            if (val.StartTime == "", val.EndTime == "") {
                IsEmpty = true;
            }
        });
        if (!IsEmpty) {
            $scope.Transfer.TimeSlots.push({ StartTime: "", EndTime: "" });
        }
        else {
            alert("Please fill empty field first");
        }
    };

    $scope.RemoveTimeSlot = function (TimeSlot) {
        if (!$scope.IsEditMode)
        {
            var index = $scope.Transfer.TimeSlots.indexOf(TimeSlot);
            $scope.Transfer.TimeSlots.splice(index, 1);
        }
        else {
            TimeSlot.IsDelete = true;
        }
        
    };

    $scope.AddBlackOut = function () {
        var IsEmpty = false;
        angular.forEach($scope.Transfer.BlackOuts, function (val) {
            if (val.StartDate == "", val.EndDate == "") {
                IsEmpty = true;
            }
        });
        if (!IsEmpty) {
            $scope.Transfer.BlackOuts.push({ StartDate: "", EndDate: "" });
        }
        else {
            alert("Please fill empty field first");
        }
    };

    $scope.RemoveBlackOut = function (BlackOut) {
        if (!$scope.IsEditMode) {
            var index = $scope.Transfer.BlackOuts.indexOf(BlackOut);
            $scope.Transfer.BlackOuts.splice(index, 1);
        }
        else {
            BlackOut.IsDelete = true;
        }
        
    };

    $scope.AddVehicleType = function () {
        var IsEmpty = false;
        angular.forEach($scope.Transfer.VehicleTypes, function (val) {
            if (val.VehicleTypes == "", val.RatePerHour == "") {
                IsEmpty = true;
            }
        });
        if (!IsEmpty) {
            $scope.Transfer.VehicleTypes.push({ VehicleTypes: "", RatePerHour: "" });
        }
        else {
            alert("Please fill empty field first");
        }
    };

    $scope.RemoveVehicleType = function (VehicleType) {
        if (!$scope.IsEditMode) {
            var index = $scope.Transfer.VehicleTypes.indexOf(VehicleType);
            $scope.Transfer.VehicleTypes.splice(index, 1);
        }
        else {
            VehicleType.IsDelete = true;
        }
        
    };

    $scope.AddPremiumDate = function () {
        var IsEmpty = false;
        angular.forEach($scope.Transfer.PremiumDates, function (val) {
            if (val.PremiumStartDate == "", val.PremiumEndDate == "", val.Rates == "") {
                IsEmpty = true;
            }
        });
        if (!IsEmpty) {
            $scope.Transfer.PremiumDates.push({ PremiumStartDate: "", PremiumEndDate: "", Rates: "" });
        }
        else {
            alert("Please fill empty field first");
        }
    };

    $scope.RemovePremiumDate = function (PremiumDate) {
        if (!$scope.IsEditMode) {
            var index = $scope.Transfer.PremiumDates.indexOf(PremiumDate);
            $scope.Transfer.PremiumDates.splice(index, 1);
        }
        else {
            PremiumDate.IsDelete = true;
        }
        
    };
   
    $scope.Save = function () {        

        angular.forEach($scope.Transfer.TimeSlots, function (TimeSlot) {
            TimeSlot.StartHour = TimeSlot.StartTime.getHours();
            TimeSlot.StartMinute = TimeSlot.StartTime.getMinutes();

            TimeSlot.EndHour = TimeSlot.EndTime.getHours();
            TimeSlot.EndMinute = TimeSlot.EndTime.getMinutes();
        });

        if (!$scope.IsEditMode)
        {
            $http.post('/Transfer/Add', $scope.Transfer).then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {

                    $scope.Transfer = {};
                    $scope.ViewMode = "list";
                    alert(successResponse.data.Message);

                }
                else {

                    alert(successResponse.data.Message);

                }
            },
              function (errorResponse) {

              });
        }
        else {
            $http.post('/Transfer/Edit', $scope.Transfer).then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {

                    $scope.Transfer = {};
                    $scope.ViewMode = "list";
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

    $scope.GetAllTransfers = function () {
        $http.get('/Transfer').then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {

                      $scope.Transfers = successResponse.data.ChangedData;

                  }
                  else {

                      alert(successResponse.data.Message);

                  }
              },
              function (errorResponse) {
                  // handle errors here
              });
    };  

    $scope.Edit = function (Transfer) {

        $scope.ViewMode = "new";
        $scope.IsEditMode = true;
        $scope.Transfer = Transfer;
        $scope.Transfer.TransferTypeId = $scope.Transfer.TransferTypeId.toString();
        $scope.Transfer.TransferCategoryId = $scope.Transfer.TransferCategoryId.toString();       

        $scope.Transfer.DurationHour = $scope.Transfer.DurationHour.toString();
        $scope.Transfer.DurationMinute = $scope.Transfer.DurationMinute.toString();


        angular.forEach($scope.Transfer.TimeSlots, function (TimeSlot) {
            TimeSlot.StartTime = new Date(0, 0, 0, TimeSlot.StartHour, TimeSlot.StartMinute);
            TimeSlot.EndTime = new Date(0, 0, 0, TimeSlot.EndHour, TimeSlot.EndMinute);

        });
        
        angular.forEach($scope.Transfer.BlackOuts, function (BlackOut) {
            BlackOut.BlackOutStartDate = new Date(BlackOut.BlackOutStartDate);
            BlackOut.BlackOutEndDate = new Date(BlackOut.BlackOutEndDate);
        });

        angular.forEach($scope.Transfer.PremiumDates, function (PremiumDate) {
            PremiumDate.PremiumStartDate = new Date(PremiumDate.PremiumStartDate);
            PremiumDate.PremiumEndDate = new Date(PremiumDate.PremiumEndDate);
        });
        

    };

    $scope.Cancel = function () {
        $scope.ViewMode = "list";
    };

    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });    

}]);