myapp.service('myappService', ["$rootScope", "$http","$location",
    function ($rootScope, $http,$location) {
        var masterReadyEvent = 'CollectedMasters';
        var masterReadyArgs = ['arg'];

        var loginChangeEvent = 'LoginChange';

        var MasterObject = {};

        $rootScope.GetMasters = function () {
            console.log("Getting Masters");
            $http.get('\Start').then(
                 function (successResponse) {
                     if (successResponse.data.isSuccess) {
                         MasterObject = successResponse.data.ChangedData;
                         console.log(MasterObject);
                         $rootScope.$broadcast(masterReadyEvent, masterReadyArgs);
                     }
                     else {

                         alert(successResponse.data.Message);
                     }
                 },
                function (errorResponse) {
                    // handle errors here
                }
                );
        };

        this.GetAgencyTierLevels = function () {
            return MasterObject.AgencyTierLevels || [];
        };

        this.GetCountries = function () {
            return MasterObject.Countries || [];
        };

        this.GetRoles = function () {
            return MasterObject.Roles || [];
        };

        this.GetAgencies = function () {
            return MasterObject.Agencies || [];
        };

        this.GetBankAccountTypes = function () {
            return MasterObject.BankAccountTypes || [];
        };

        this.GetDMCOfficialTypes = function () {
            return MasterObject.DMCOfficialTypes || [];
        };

        this.IsAuthenticated = function () {
            return MasterObject.IsAuthenticated || false;
        };

        this.GetUser = function () {
            return MasterObject.User || {};
        };

        this.GetMaster = function () {
            $rootScope.GetMasters();
        };

        this.Login = function (model,returnURL) {
            var IsSuccess = false;
            $http.post('/Account/Login', model).then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {
                      MasterObject.IsAuthenticated = true;
                      MasterObject.User = successResponse.data.ChangedData.User;
                      $rootScope.$broadcast(loginChangeEvent, masterReadyArgs);
                      alert(successResponse.data.Message);

                      console.log(successResponse.data.ChangedData);
                      IsSuccess = true;
                      $location.url(returnURL);
                     
                  }
                  else {

                      alert(successResponse.data.Message);
                     
                  }
              },
              function (errorResponse) {
                 
                  // handle errors here
              });

           
        };

        $rootScope.CallInitiators = function () {
            $rootScope.GetMasters();
        };

        $rootScope.CallInitiators();

    }]);