myapp.controller('DMCController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

    $scope.ViewMode = "list";
    $scope.IsEditMode = false;

    $scope.DMCS = [];

    $scope.CreateInitialDMCObject = function () {
        $scope.DMC = {};
        $scope.DMC.AdditionalOfficePhoneNumbers = [];
        $scope.AddOfficePhoneNumber();
        
        $scope.DMC.BankDetails = [];
        $scope.AddBankDetail();
        $scope.DMC.DMCOfficials = [];
        $scope.AddDMCOfficial();

    };

    $scope.InitializeDMCSearchObject = function () {
        $scope.SearchDMC = {};
    };

    $scope.AddOfficePhoneNumber = function () {
        var IsEmpty = false;
        angular.forEach($scope.DMC.AdditionalOfficePhoneNumbers, function (val) {
            if (val.PhoneNumber == "") {
                IsEmpty = true;
            }
        });

        if (!IsEmpty)
        {
            $scope.DMC.AdditionalOfficePhoneNumbers.push({ PhoneNumber: "" });
        }
        else {
            alert("Please fill empty field first");
        }
        
    };

    $scope.RemovePhoneNumber = function (PhoneNumber) {
        var index = $scope.DMC.AdditionalOfficePhoneNumbers.indexOf(PhoneNumber);
        $scope.DMC.AdditionalOfficePhoneNumbers.splice(index, 1);

        $scope.dmcForm.$setSubmitted();

    };

    $scope.AddBankDetail = function () {
        var BankDetail = {};
        $scope.DMC.BankDetails.push(BankDetail);
    };

    $scope.RemoveBankDetail = function (BankDetail) {
        BankDetail.IsDelete = true;
    };

    $scope.AddDMCOfficial = function () {
        var DMCOfficial = {};
        $scope.DMC.DMCOfficials.push(DMCOfficial);
    };

    $scope.RemoveDMCOfficial = function (DMCOfficial) {
        DMCOfficial.IsDelete = true;

    };

    $scope.LoadData = function () {
        $scope.CreateInitialDMCObject();
        $scope.InitializeDMCSearchObject();
        $scope.Countries = myappService.GetCountries();

        $scope.BankAccountTypes = myappService.GetBankAccountTypes();
        $scope.DMCOfficialTypes = myappService.GetDMCOfficialTypes();
        $scope.GetDMCS();
    };

    $scope.CollateOfficialPhoneNumbers = function () {

        var OfficialPhoneNumbers = "";

        angular.forEach($scope.DMC.AdditionalOfficePhoneNumbers, function (val, index) {

            if ((index + 1) == $scope.DMC.AdditionalOfficePhoneNumbers.length)
            {
                OfficialPhoneNumbers = OfficialPhoneNumbers + val.PhoneNumber;
            }
            else {
                OfficialPhoneNumbers = OfficialPhoneNumbers + val.PhoneNumber + "|";
            }
            
        });

        $scope.DMC.OfficeNumber = OfficialPhoneNumbers;
    };

    $scope.AddDMC = function () {
        $scope.CollateOfficialPhoneNumbers();
        if (!$scope.IsEditMode)
        {
            $http.post('/DMC/Add', $scope.DMC).then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {
                    $scope.CreateInitialDMCObject();
                    alert(successResponse.data.Message);

                }
                else {

                    alert(successResponse.data.Message);

                }
            },
            function (errorResponse) {
                // handle errors here
            });
        }
        else {

            $http.post('/DMC/Edit', $scope.DMC).then(
            function (successResponse) {
                if (successResponse.data.isSuccess) {
                    $scope.CreateInitialDMCObject();
                    alert(successResponse.data.Message);

                }
                else {

                    alert(successResponse.data.Message);

                }
            },
            function (errorResponse) {
                // handle errors here
            });
        }
       
    };

    $scope.GetDMCS = function () {
        
        $http.post('/DMC/GetDMCs', $scope.SearchDMC).then(
             function (successResponse) {
                 if (successResponse.data.isSuccess) {
                     $scope.DMCS = successResponse.data.ChangedData;
                     $scope.InitializeDMCSearchObject();
                 }
                 else {

                     alert(successResponse.data.Message);

                 }
             },
             function (errorResponse) {
                 // handle errors here
             });

    };

    $scope.CancelForm = function () {
        $scope.CreateInitialDMCObject();
        $scope.InitializeDMCSearchObject();
        $scope.ViewMode = "list";
    };

    $scope.MakeNewDMCMode = function () {
        $scope.ViewMode = "new";
        $scope.IsEditMode = false;
    };

    $scope.Edit = function (DMC) {
        $scope.IsEditMode = true;
        $scope.ViewMode = "new";
        $scope.DMC = DMC;
        $scope.DMC.CountryId = DMC.CountryId.toString();
        $scope.DMC.AdditionalOfficePhoneNumbers = [];
        if($scope.DMC.OfficeNumber.indexOf('|')>0 )
        {
            var PhoneNumbers = $scope.DMC.OfficeNumber.split('|');

            angular.forEach(PhoneNumbers, function (PhoneNumber) {
                $scope.DMC.AdditionalOfficePhoneNumbers.push({ PhoneNumber: PhoneNumber });
            });
        }
        else {
            $scope.DMC.AdditionalOfficePhoneNumbers.push({ PhoneNumber: $scope.DMC.OfficeNumber });
        }

        angular.forEach($scope.DMC.BankDetails, function (BankDetail) {
            BankDetail.BankAccountTypeId = BankDetail.BankAccountTypeId.toString();
        });

        angular.forEach($scope.DMC.DMCOfficials, function (DMCOfficial) {
            DMCOfficial.DMCOfficialTypeId = DMCOfficial.DMCOfficialTypeId.toString();
        });
    };

    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });
}]);