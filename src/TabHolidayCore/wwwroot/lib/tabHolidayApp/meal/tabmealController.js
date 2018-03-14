myapp.controller('MealController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.ViewMode = "list";

    $scope.Meal = {};
    


    $scope.GetAllTabMeals = function () {
        $http.get('/Meal').then(
              function (successResponse) {
                  if (successResponse.data.isSuccess) {

                      $scope.TabMeals = successResponse.data.ChangedData;

                  }
                  else {

                      alert(successResponse.data.Message);

                  }
              },
              function (errorResponse) {
                  // handle errors here
              });
    };


    $scope.GetTabMeals = function () {

        $http.post('/Meal/GetTabMeals', $scope.Meal).then(
             function (successResponse) {
                 if (successResponse.data.isSuccess) {
                     $scope.TabMeals = successResponse.data.ChangedData;
                    
                 }
                 else {

                     alert(successResponse.data.Message);

                 }
             },
             function (errorResponse) {
                 // handle errors here
             });

    };


    $scope.LoadData = function () {
        $scope.FoodTypes = myappService.GetFoodTypes();
        $scope.RestaurantTypes = myappService.GetRestaurantTypes();
        $scope.GetAllTabMeals();
        $scope.GetTabMeals();
       
        
    };

    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });

    $scope.Save = function () {
     
            $scope.Meal.OpeningHour = Meal.OpeningTime.getHours();
            $scope.Meal.OpeningMinute = Meal.OpeningTime.getMinutes();

            $scope.Meal.ClosingHour = Meal.ClosingTime.getHours();
            $scope.Meal.ClosingMinute = Meal.ClosingTime.getMinutes();
        
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


    $scope.Edit = function (TabMeal) {

        $scope.IsEditMode = true;
        $scope.ViewMode = "new";
        $scope.Meal = TabMeal;
        $scope.Meal.FoodTypeId = $scope.Meal.FoodTypeId.toString();
        $scope.Meal.RestaurantTypeId = $scope.Meal.RestaurantTypeId.toString();
    

    };

    //$scope.Reset = function () {
    //    $scope.Meal = {};
    //    $scope.IsEditMode = false;
    //};

    $scope.InitializeTabMealSearchObject = function () {
        $scope.Meal = {};
    };
    
  
}]);