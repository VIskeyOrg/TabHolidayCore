myapp.controller('MealController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.ViewMode = "list";

    $scope.Meal = {};
    //$scope.Meals = [];

   
    
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
     
            $scope.Meal.OpeningHour = $scope.Meal.OpeningTime.getHours();
            $scope.Meal.OpeningMinute = $scope.Meal.OpeningTime.getMinutes();

            $scope.Meal.ClosingHour = $scope.Meal.ClosingTime.getHours();
            $scope.Meal.ClosingMinute = $scope.Meal.ClosingTime.getMinutes();
        
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

       
        $scope.ViewMode = "new";
        $scope.Meal = TabMeal;
        $scope.Meal.FoodTypeId = $scope.Meal.FoodTypeId.toString();
        $scope.Meal.RestaurantTypeId = $scope.Meal.RestaurantTypeId.toString();

        var d = new Date(0, 0, 0, $scope.Meal.OpeningHour, $scope.Meal.OpeningMinute);

        $scope.Meal.OpeningTime = d;
       
        var d = new Date(0, 0, 0, $scope.Meal.ClosingHour, $scope.Meal.ClosingMinute);

        $scope.Meal.ClosingTime = d;
       
    };

    $scope.Cancel = function () {
        $scope.ViewMode = "list";
    };

  

    $scope.InitializeTabMealSearchObject = function () {
        $scope.Meal = {};
    };
    
  
}]);