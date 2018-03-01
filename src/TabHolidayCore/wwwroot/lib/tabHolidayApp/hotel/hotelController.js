myapp.controller('HotelController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.Hotel = {};
    $scope.FacilityMode = "view";
    $scope.MealMode = "view";


    $scope.LoadData = function () {
        $scope.GetAllFacilities();
        $scope.Meals = myappService.GetAllMeals();

    };

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });

    $scope.Save = function () {

        $http.post('/Hotel/Add', $scope.Hotel).then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {

                    $scope.Hotel = {};
                    alert(successResponse.data.Message);

                }
                else {

                    alert(successResponse.data.Message);

                }
            },
              function (errorResponse) {

              });

    };
   
    $scope.GetAllFacilities = function () {
        $http.get('/Facility/').then(
           function (successResponse) {
               if (successResponse.data.isSuccess) {

                   $scope.Facilities = [];
                   $scope.Facilities = successResponse.data.ChangedData;

                   angular.forEach($scope.Facilities, function (Facility) {
                       Facility.Selected = false;
                   });

               }
               else {

                   alert(successResponse.data.Message);

               }
           },
             function (errorResponse) {

             });
    };

    $scope.SelectFacility = function (Facility) {

        Facility.Selected = !Facility.Selected;
    };

    $scope.AddFacilities = function () {
        $scope.FacilityMode = 'view';
        $scope.Hotel.Facilities = [];
        angular.forEach($scope.Facilities, function (facility) {
            if (facility.Selected) {
                $scope.Hotel.Facilities.push(facility);
            }
        });
    };
         

    $scope.AddMeals = function () {
        $scope.MealMode = 'add';

    };

    $scope.PushMeals = function () {
        $scope.MealMode = 'view';
        $scope.Hotel.Meals = [];
        angular.forEach($scope.Meals, function (Meal) {
            if (Meal.Selected) {
                $scope.Hotel.Meals.push(Meal);
            }
        });
    };

}]);