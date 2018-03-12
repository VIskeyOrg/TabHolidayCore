myapp.controller('VehicleTypeController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.VehicleTypes = [];
    $scope.VehicleType = {};

    $scope.LoadData = function () {
        $scope.GetAllVehicleTypes();
    };


    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();
    });

    $scope.Save = function () {
        $http.post('/VehicleType/Add', $scope.VehicleType).then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {

                      $scope.VehicleType = {};
                      $scope.GetAllVehicleTypes();
                      alert(successResponse.data.Message);

                  }
                  else {

                      alert(successResponse.data.Message);

                  }
              },
              function (errorResponse) {
                  
              });

    };

    $scope.GetAllVehicleTypes = function () {
        $http.get('/VehicleType').then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {

                      $scope.VehicleTypes = successResponse.data.ChangedData;

                  }
                  else {

                      alert(successResponse.data.Message);

                  }
              },
              function (errorResponse) {
                  
              });
    };



}]);