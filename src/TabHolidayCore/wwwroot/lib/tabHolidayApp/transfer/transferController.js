myapp.controller('TransferController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.Transfer = {};
    $scope.Transfer.TimeSlots = [];
    $scope.Transfer.BlackOuts = [];
    $scope.Transfer.VehicleTypes = [];

    $scope.LoadData = function () {
         if ($scope.Transfer.TimeSlots < 1) {
            $scope.AddTimeSlot();
         }

         if ($scope.Transfer.BlackOuts < 1) {
             $scope.AddBlackOut();
         }

         if ($scope.Transfer.VehicleTypes < 1) {
             $scope.AddVehicleType();
         }


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
        var index = $scope.Transfer.TimeSlots.indexOf({ StartTime: "", EndTime: "" });
        $scope.Transfer.TimeSlots.splice(index, 1);
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
        var index = $scope.Transfer.BlackOuts.indexOf({ StartDate: "", EndDate: "" });
        $scope.Transfer.BlackOuts.splice(index, 1);
    };

    $scope.AddVehicleType = function () {
        var IsEmpty = false;
        angular.forEach($scope.Transfer.VehicleTypes, function (val) {
            if (val.VehicleType == "", val.RatePerHour == "") {
                IsEmpty = true;
            }
        });
        if (!IsEmpty) {
            $scope.Transfer.VehicleTypes.push({ VehicleType: "", RatePerHour: "" });
        }
        else {
            alert("Please fill empty field first");
        }
    };

    $scope.RemoveVehicleType = function (VehicleType) {
        var index = $scope.Transfer.VehicleTypes.indexOf({ VehicleType: "", RatePerHour: "" });
        $scope.Transfer.VehicleTypes.splice(index, 1);
    };

    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });


}]);