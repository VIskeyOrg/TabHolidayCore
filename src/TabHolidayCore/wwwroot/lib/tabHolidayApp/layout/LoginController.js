myapp.controller('LoginController', ['$http', '$scope', '$location', 'myappService', '$filter', '$window', function ($http, $scope, $location, myappService, $filter, $window) {
    $scope.DispalyName = "Guest";
       

    //Load Data

   

    $scope.LoadData = function () {

        $scope.IsAuthenticated = myappService.IsAuthenticated();
        if ($scope.IsAuthenticated)
        {
            $scope.User = myappService.GetUser();

            if ($scope.User.ActualName == null)
            {
                $scope.DispalyName = $scope.User.UserName;
            }
            else {
                $scope.DispalyName = $scope.User.ActualName;
            }
           
        }
        else
        {
            $scope.DispalyName = "Guest";
        }     

        
    };

    $scope.Logout = function () {
        $http.post('/Account/LogOff').then(
              function (successResponse) {
                  myappService.GetMaster();
                  $window.location.reload()

              },
              function (errorResponse) {
                  myappService.GetMaster();
                  $window.location.reload()
              });

        
    };

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();
    });

    $scope.$on("LoginChange", function () {
        $scope.LoadData();
    });

    $scope.LoadData();
}]);