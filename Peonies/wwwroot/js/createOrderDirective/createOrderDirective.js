angular.module('phonecatApp').directive('createOrderDirective',
    function () {
        return {
            restrict: 'E',

            scope: {
                name: '=',
                peonies: '=',
                clientId: '='
            },
            controller: ['$scope', '$rootScope', '$http', function MyTabsController($scope, $rootScope, $http) {
           
                $scope.selectionChange = function () {
                    
                    debugger;
                };

                
                function GetPeonies() {
                    $scope.clientId;
                    debugger;


                    if ($scope.child != true) {
                        $http({
                            method: 'GET',
                            url: `https://localhost:44362/Peony/index`
                        }).then(function successCallback(response) {
                            $scope.PeoniesSelect = response.data;
                            debugger;
                        });
                    }
                };
                GetPeonies();
                $scope.Add = function (peony, amount) {
                    debugger;
                    $scope.fullPrice = peony.price * amount;

                    $http({
                        method: 'POST',
                        url: `https://localhost:44362/Order/Add?amount=${amount}&fullprice=${$scope.fullPrice}&peonyId=${peony.peonyId}&clientId=${$scope.clientId}`
                    }).then(function successCallback(response) {
                        $scope.PeoniesSelect = response.data;
                        debugger;
                    });

                    debugger;
                }

            }],

            templateUrl: '../../js/createOrderDirective/createOrderDirective.html'
        };
    }
);