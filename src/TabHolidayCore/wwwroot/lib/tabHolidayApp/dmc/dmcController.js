myapp.controller('DMCController', ['$http', '$scope', '$location', 'myappService', '$filter', function ($http, $scope, $location, myappService, $filter) {

   

    $scope.CreateInitialDMCObject = function () {
        $scope.DMC = {};
        $scope.DMC.AdditionalOfficePhoneNumbers = [];
        $scope.AddOfficePhoneNumber();
        
        $scope.DMC.BankDetails = [];
        $scope.AddBankDetail();
        $scope.DMC.DMCOfficials = [];
        $scope.AddDMCOfficial();

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
        var index = $scope.DMC.BankDetails.indexOf(BankDetail);
        $scope.DMC.BankDetails.splice(index, 1);
    };

    $scope.AddDMCOfficial = function () {
        var DMCOfficial = {};
        $scope.DMC.DMCOfficials.push(DMCOfficial);
    };

    $scope.RemoveDMCOfficial = function (DMCOfficial) {
        var index = $scope.DMC.DMCOfficials.indexOf(DMCOfficial);
        $scope.DMC.DMCOfficials.splice(index, 1);

    };

    $scope.LoadData = function () {
        $scope.CreateInitialDMCObject();
        $scope.Countries = myappService.GetCountries();

        $scope.BankAccountTypes = myappService.GetBankAccountTypes();
        $scope.DMCOfficialTypes = myappService.GetDMCOfficialTypes();
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
    };

    $scope.LoadData();

    $scope.$on("CollectedMasters", function () {
        $scope.LoadData();

    });
}]);