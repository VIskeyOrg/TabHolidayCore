tabHolidayApp.service('myappService', ["$rootScope",
    function ($rootScope) {
		
       var  Itinarery = [];

       var TempActivity = {};

        this.SetTempActivity = function(Activity,Day){
            TempActivity.Activity=Activity;
            TempActivity.Day=Day;
        };

        this.GetTempActivity = function () {
            return TempActivity || {};
        };

        this.AddActivityToItinarery = function (Activity, Day) {
            var ItinareryObj = {};
            angular.forEach(Itinarery || [], function (object) {
                if(object.Day == Day)
                {
                    ItinareryObj = object;
                    if (ItinareryObj.Activities === undefined)
                    {
                        ItinareryObj.Activities = [];
                    }
                    ItinareryObj.Activities.push(Activity);
                }
            });
            
            if( $.isEmptyObject(ItinareryObj))
            {
                ItinareryObj.Day = Day;
                ItinareryObj.Activities = [];
                ItinareryObj.Activities.push(Activity);
                Itinarery.push(ItinareryObj);
            }
            
        };

        this.AddMealToItinerary = function (Meal, Day) {
            var ItinareryObj = {};
            angular.forEach(Itinarery || [], function (object) {
                if (object.Day == Day) {
                    ItinareryObj = object;
                    ItinareryObj.Meal = Meal
                }
            });

            if ($.isEmptyObject(ItinareryObj)) {
                ItinareryObj.Day = Day;
                ItinareryObj.Meal = Meal;
                
                Itinarery.push(ItinareryObj);
            }

        };

        this.GetItinerary = function () {
            return Itinarery || [];
        };

        this.AddDubaiHotels = function () {
            for (var i = 1; i < 5; i++) {
                var found = false;
                angular.forEach(Itinarery || [], function (object) {
                    if (object.Day == i) {
                        object.Hotel = "Hotel Reflections (Al Karama)";
                        found = true
                    }
                });

                if (!found) {
                    Itinarery.push({Day:i,Hotel:'Hotel Reflections (Al Karama)'});
                }
            }

            
        };

        this.AddAbuDhabiHotels = function () {

            for (var i = 5; i < 8; i++) {
                var found = false;
                angular.forEach(Itinarery || [], function (object) {
                    if (object.Day == i) {
                        object.Hotel = "Hotel Trianon (Al Zarka)";
                        found = true
                    }
                });

                if (!found) {
                    Itinarery.push({ Day: i, Hotel: 'Hotel Trianon (Al Zarka)' });
                }
            }            
        };
        
	}]);