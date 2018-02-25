myapp.controller('AgencyController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.AgencyName = "Excel Agency";
    $scope.Agency = {};
    
    $scope.LoadData = function () {
        $scope.AgencyTierLevels = myappService.GetAgencyTierLevels();
        $scope.Countries = myappService.GetCountries();
        $scope.GetAllAgencies();
    };

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });

    $scope.Save = function () {
        //$scope.Agency.AgencyTierLevelId = 1;
        //$scope.Agency.CountryId = 194;
        $http.post('/Agency/Add', $scope.Agency).then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {
                      $scope.Agency = {};
                      $scope.GetAllAgencies();
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

    $scope.Edit = function (Agency) {
        $scope.IsEditMode = true;
        $scope.Agency = Agency;
        $scope.Agency.AgencyTierLevelId = String(Agency.AgencyTierLevelId);
        $scope.Agency.CountryId = String(Agency.CountryId);
    };

    $scope.GetAllAgencies = function () {
        $http.get('/Agency').then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {
                      
                      $scope.Agencies = successResponse.data.ChangedData;

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
        $scope.Agency = {};
        $scope.IsEditMode = false;
    };

    $scope.LoadData();

    

    
}]);