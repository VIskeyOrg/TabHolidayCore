myapp.controller('Login1Controller', ['$http', '$scope', '$location', 'myappService', function ($http, $scope, $location, myappService) {
    $scope.model = {};
    $scope.Submit = function () {
        
        var IsSuccess = myappService.Login($scope.model,"/");
        $scope.model = {};
        
    };
}]);

