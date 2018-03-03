myapp.controller('FacilityController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.Facilities = [];
    $scope.Facility = {};

    $scope.LoadData = function () {
        $scope.GetAllFacilities();
    };


    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();
    });

    $scope.Save = function () {
        $http.post('/Facility/Add', $scope.Facility).then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {

                      $scope.Facility = {};
                      $scope.GetAllFacilities();
                      alert(successResponse.data.Message);

                  }
                  else {

                      alert(successResponse.data.Message);

                  }
              },
              function (errorResponse) {
                  // handle errors here
              });

    };

    $scope.Edit = function (Facility) {

        $scope.Facility = Facility;

    };

    $scope.Delete = function (Facility) {

        $http.post('/Facility/Delete', Facility).then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {

                      $scope.GetAllFacilities()
                      alert(successResponse.data.Message);

                  }
                  else {

                      alert(successResponse.data.Message);

                  }
              },
              function (errorResponse) {
                  // handle errors here
              });

    };


    $scope.GetAllFacilities = function () {
        $http.get('/Facility').then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {

                      $scope.Facilities = successResponse.data.ChangedData;

                  }
                  else {

                      alert(successResponse.data.Message);

                  }
              },
              function (errorResponse) {
                  // handle errors here
              });
    };

    $scope.Reset = function () {
        $scope.Facility = {};
        $scope.IsEditMode = false;
    };

    $scope.LoadData();

}]);
