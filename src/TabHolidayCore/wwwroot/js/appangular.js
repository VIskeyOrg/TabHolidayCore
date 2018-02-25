var myapp = angular.module('myapp', []);

myapp.controller('mainController', ['$scope', 'myappService', function ($scope, myappService) {
    $scope.Itinerary = [];
    $scope.SetTempActivity = function (Activity) {
        myappService.SetTempActivity(Activity, $scope.SelectedDay);
    };

    $scope.SelectDay = function () {
        $scope.SelectedDay = parseInt($scope.TxtSelectedDay);
    };

    $scope.GetItinerary = function () {
        $scope.Itinerary = myappService.GetItinerary();
    };

    $scope.AddMeal = function (Meal) {
        var MealString = "Meal - " + Meal;
        myappService.AddActivityToItinarery(MealString, $scope.SelectedDay);
    };

    $scope.AddDubaiHotel = function () {
        myappService.AddDubaiHotels();
    };

    $scope.AddAbuDhabiHotel = function () {
        myappService.AddAbuDhabiHotels();
    };
    $scope.GetItinerary();
}]);

myapp.controller('ScheduleFlightController', ['$scope', 'myappService', function ($scope, myappService) {
    $scope.timeslots = [];
    console.log($scope.timeslots)

    $scope.timeslots.push({ timeslot: "07:00", status: "available" });
    $scope.timeslots.push({ timeslot: "08:00", status: "available" });
    $scope.timeslots.push({ timeslot: "09:00", status: "available" });
    $scope.timeslots.push({ timeslot: "10:00", status: "available" });
    $scope.timeslots.push({ timeslot: "12:00", status: "available" });
    $scope.timeslots.push({ timeslot: "14:00", status: "available" });
    $scope.timeslots.push({ timeslot: "16:00", status: "available" });
    $scope.timeslots.push({ timeslot: "17:00", status: "available" });
    $scope.timeslots.push({ timeslot: "18:00", status: "available" });
    $scope.timeslots.push({ timeslot: "20:00", status: "available" });
    $scope.timeslots.push({ timeslot: "21:00", status: "available" });
    $scope.timeslots.push({ timeslot: "22:00", status: "available" });

    $scope.passengercounts = [0,1, 2, 3, 4, 5, 6, 7, 8];

    $scope.adultfare = 8.5;
    $scope.chiildfare = 8.5;
    $scope.infantfare = 0;
    $scope.childcount = 0;
    $scope.adultcount = 0;
    $scope.infantcount = 0;
    $scope.totalfare = 0;
    $scope.Activity = {};

    $scope.GetTempActivity = function () {
        $scope.Activity=myappService.GetTempActivity();
    };

    $scope.AddActivity = function () {
        var Activity =  $scope.Activity.Activity + " - " + $scope.SelectedTimeSlot.timeslot;
        myappService.AddActivityToItinarery(Activity, $scope.Activity.Day);
        $('button[title="Close (Esc)"]').click()
    };

    $scope.SelectTimeSlot = function (timeslot) {
        angular.forEach($scope.timeslots || [], function (object) {
            object.active = false;
        });
        timeslot.active = true;
        $scope.SelectedTimeSlot = timeslot;
    };

    $scope.GetTotalFare = function () {
        $scope.totalfare = $scope.childcount * $scope.chiildfare + $scope.adultcount * $scope.adultfare + 0;
       
    };

    $scope.ChangeChildCount = function () {
        $scope.childcount = parseInt($scope.SelectedChildCCount);
        $scope.GetTotalFare();
    };

    $scope.ChangeAdultCount = function () {
        $scope.adultcount = parseInt($scope.SelectedAdultCount);
        $scope.GetTotalFare();
        
    };

    $scope.ChangeInfantCount = function () {
        $scope.infantcount = parseInt($scope.SelectedInfantCount);
        $scope.GetTotalFare();
    };

    $scope.GetTempActivity();
}]);