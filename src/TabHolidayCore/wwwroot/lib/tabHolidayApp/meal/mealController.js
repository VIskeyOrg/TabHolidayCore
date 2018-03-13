myapp.controller('MealController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.Meal = {};

    $scope.LoadData = function () {
        $scope.FoodTypes = myappService.GetFoodTypes();
        $scope.RestaurantTypes = myappService.GetRestaurantTypes();

    };
    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });

    $scope.Save = function () {


        $http.post('/Meal/Add', $scope.Meal).then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {

                    $scope.Meal = {};
                    alert(successResponse.data.Message);

                }
                else {

                    alert(successResponse.data.Message);

                }
            },
              function (errorResponse) {

              });

    };
  
}]);