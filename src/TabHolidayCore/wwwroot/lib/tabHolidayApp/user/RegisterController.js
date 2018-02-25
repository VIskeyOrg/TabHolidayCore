myapp.controller('RegisterController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService,$filter) {
    $scope.model = {};
    $scope.pagination = {};
    $scope.pagination.Role = "All";
    $scope.pagination.Take = 10;
    $scope.pagination.Skip = 0;
    $scope.pagination.CurrentPageNumber = 1;
    $scope.pagination.TotalRecords = 0;
    $scope.pagination.pager = {};
       

    $scope.Submit = function () {
        $http.post('/Account/AddUser', $scope.model).then(
               function (successResponse) {
                   if (successResponse.data.isSuccess) {
                       $scope.model = {};
                       alert(successResponse.data.Message);
                       $scope.GetUserList();
                   }
                   else {

                       alert(successResponse.data.Message);

                   }
               },
               function (errorResponse) {
                   // handle errors here
               });
    };

    

    $scope.SetAgencyTierLevel = function () {
        $scope.model.Agency.AgencyTierLevelId = parseInt($scope.model.Agency.AgencyTierLevelIdStr);
    };

    $scope.SetCountry = function () {
        $scope.model.Agency.CountryId = parseInt($scope.model.Agency.CountryIdStr);
    };

    $scope.GetUserList = function () {

        $scope.requestObject = { skip: ($scope.pagination.CurrentPageNumber - 1) * $scope.pagination.Take, take: $scope.pagination.Take, Role: $scope.pagination.Role };

        $http.get('/Account/GetUsersCount').then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {
                    $scope.pagination.TotalRecords = parseInt(successResponse.data.ChangedData);

                    $scope.pagination.pager = $scope.GetPager($scope.pagination.TotalRecords, $scope.pagination.CurrentPageNumber, $scope.pagination.Take);
                }
                else {

                    alert(successResponse.data.Message);

                }
            },
            function (errorResponse) {
            });

        $http.post('/Account/GetUserList', $scope.requestObject).then(
           function (successResponse) {
               if (successResponse.data.isSuccess) {
                   console.log("All Users");
                   console.log(successResponse.data.ChangedData);
                   $scope.Users = successResponse.data.ChangedData;
               }
               else {

                   alert(successResponse.data.Message);

               }
           },
           function (errorResponse) {
           });
    };

    //Pagination
    $scope.GetPager = function (totalItems, currentPage, pageSize) {
        // default to first page
        currentPage = currentPage || 1;

        // default page size is 10
        pageSize = pageSize || 10;

        // calculate total pages
        var totalPages = Math.ceil(totalItems / pageSize);

        var startPage, endPage;
        if (totalPages <= 10) {
            // less than 10 total pages so show all
            startPage = 1;
            endPage = totalPages;
        } else {
            // more than 10 total pages so calculate start and end pages
            if (currentPage <= 6) {
                startPage = 1;
                endPage = 10;
            } else if (currentPage + 4 >= totalPages) {
                startPage = totalPages - 9;
                endPage = totalPages;
            } else {
                startPage = currentPage - 5;
                endPage = currentPage + 4;
            }
        }

        // calculate start and end item indexes
        var startIndex = (currentPage - 1) * pageSize;
        var endIndex = Math.min(startIndex + pageSize - 1, totalItems - 1);

        // create an array of pages to ng-repeat in the pager control
        var pages = [];

        for (var i = startPage; i < endPage + 1; i += 1) {
            pages.push(i);
        }

        // return object with all pager properties required by the view
        return {
            totalItems: totalItems,
            currentPage: currentPage,
            pageSize: pageSize,
            totalPages: totalPages,
            startPage: startPage,
            endPage: endPage,
            startIndex: startIndex,
            endIndex: endIndex,
            pages: pages
        };
    };

    $scope.setPage = function (PageNumber) {
        if (PageNumber < 1 || PageNumber > $scope.pagination.pager.totalPages) {
            return;
        }

        $scope.CurrentPageNumber = PageNumber;

        $scope.GetUserList();
        // get pager object from service

    };

    //Load Data

    $scope.LoadData = function () {
        $scope.Countries = $filter('orderBy')(myappService.GetCountries(), "Name", false);

        $scope.AgencyTierLevels = myappService.GetAgencyTierLevels();
        $scope.Roles = myappService.GetRoles();
        $scope.Agencies = myappService.GetAgencies();
        $scope.setPage(1);
    };

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();
    });

    $scope.LoadData();

    $scope.RoleChange = function () {
        if($scope.model.Role == "Admin - Travel Agent" || $scope.model.Role == "Normal - Travel Agent")
        {
            if ($scope.model.AgencyId == "0" || $scope.model.AgencyId===undefined)
            {

            }
            else {

            }
        }
    };
}]);

myapp.directive('checkAvailability', ['$http', '$q', '$timeout', function ($http, $q, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attr, ngModel) {
            // fetch the call address from directives 'checkIfAvailable' attribute


            ngModel.$asyncValidators.userExist = function (modelValue, viewValue) {
                var Username = modelValue;
                var deferred = $q.defer();
                
                $http.post('/Account/CheckUsernameAvailable', JSON.stringify(Username)).then(
               function (successResponse) {
                   if (successResponse.data.isSuccess) {
                      
                       if(successResponse.data.ChangedData == true)
                       {
                           deferred.resolve();
                       }
                       else {
                           deferred.reject();
                       }
                   }
                   else {

                       alert(successResponse.data.Message);

                   }
               },
               function (errorResponse) {
                   // handle errors here
               });

                

                // return the promise of the asynchronous validator
                return deferred.promise;
            }
        }
    }
}]);

myapp.directive('requireAgency', function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            function validator(modelVal, viewVal) {
                var role = scope.model.Role;
                var agency =parseInt( modelVal);
                var isValid = true;
                if (role == 'Admin - Travel Agent' || role == 'Normal - Travel Agent')
                {
                    if (agency <= 0 || modelVal === undefined)
                    {
                        isValid = false;
                    }
                }
                return isValid;

            }
            ctrl.$validators.requireAgency = validator;
            scope.$watch('model.Role', function () {
                ctrl.$setValidity("requireAgency", validator(scope.model.AgencyId));
            })              
        }
    }
});

myapp.directive('requireOption', function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attrs, ctrl) {
            function validator(modelVal, viewVal) {
               
                var value = parseInt(modelVal);
                var isValid = true;
                if (value <= 0 || modelVal === undefined) {
                    isValid = false;
                }
                
                return isValid;

            }
            ctrl.$validators.requireOption = validator;            
        }
    }
});


