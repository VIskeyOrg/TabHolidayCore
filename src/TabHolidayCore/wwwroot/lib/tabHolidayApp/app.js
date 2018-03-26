var myapp = angular.module('myapp', ['ngRoute', 'ui.bootstrap', 'angular.filter', 'ngMessages']);

myapp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/user', {
                templateUrl: '/lib/tabHolidayApp/user/Register.html'
            }).
            when('/login', {
                templateUrl: '/lib/tabHolidayApp/user/Login.html'
            }).
             when('/agency', {
                 templateUrl: '/lib/tabHolidayApp/agency/agency.html'
             }).
            when('/dmc', {
                templateUrl: '/lib/tabHolidayApp/dmc/dmc.html'
            }).
            when('/facility', {
                templateUrl: '/lib/tabHolidayApp/facility/facility.html'
            }).
            when('/hotel', {
                templateUrl: '/lib/tabHolidayApp/hotel/hotel.html'
            }).
            when('/sightseeing', {
                templateUrl: '/lib/tabHolidayApp/sightseeing/sightseeing.html'
            }).
            when('/transfer', {
                templateUrl: '/lib/tabHolidayApp/transfer/transfer.html'
            }).
            when('/meal', {
                templateUrl: '/lib/tabHolidayApp/meal/meal.html'
            }).
            when('/approval', {
                templateUrl: '/lib/tabHolidayApp/approval/approval.html'
            }).

            when('/vehicletype', {
                templateUrl: '/lib/tabHolidayApp/vehicletype/vehicletype.html'
            }).

            when('/sight', {
                templateUrl: '/lib/tabHolidayApp/sight/sight.html'
            }).
            when('/agegroup', {
                templateUrl: '/lib/myapp/AgeGroup/Index.html'
            }).
            when('/profile', {
                templateUrl: '/lib/myapp/Profile/Index.html'
            }).
            when('/product', {
                templateUrl: '/lib/myapp/Product/ProductAdd.html'
            }).
            when('/productlist', {
                templateUrl: '/lib/myapp/Product/ProductList.html'
            }).
            when('/productlist1', {
                templateUrl: '/lib/myapp/Product/ProductList1.html'
            }).
             when('/imageupload', {
                 templateUrl: '/lib/myapp/Product/ImageUpload.html'
             }).
            when('/plan', {
                templateUrl: '/lib/myapp/Plan/Index.html'
            }).
            when('/selectplan', {
                templateUrl: '/lib/myapp/Plan/SelectPlan.html'
            }).
            when('/myplanrequests', {
                templateUrl: '/lib/myapp/PlanRequest/MyPlanRequests.html'
            }).
             when('/myplanrequests2', {
                 templateUrl: '/lib/myapp/PlanRequest/MyPlanRequest2.html'
             }).
            when('/allplanrequests', {
                templateUrl: '/lib/myapp/PlanRequest/AllPlanRequests.html'
            }).
            otherwise({
                templateUrl: '/lib/tabHolidayApp/Index.html'
            })
    }
]);

myapp.directive('ngConfirmClick', [
        function () {
            return {
                link: function (scope, element, attr) {
                    var msg = attr.ngConfirmClick || "Are you sure?";
                    var clickAction = attr.confirmedClick;
                    element.bind('click', function (event) {
                        if (window.confirm(msg)) {
                            scope.$eval(clickAction)
                        }
                    });
                }
            };
        }])