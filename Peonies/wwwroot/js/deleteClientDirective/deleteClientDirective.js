angular.module('phonecatApp').directive('deleteClientDirective',
    function () {
        return {
            restrict: 'E',

            scope: {
                name: '=',
                clientId: '='
            },
            controller: ['$scope', '$rootScope', '$http', function MyTabsController($scope, $rootScope, $http) {
                $scope.Delete = function () {
                    debugger;

                    $http({
                        method: 'POST',
                        url: `https://localhost:44362/Client/delete?clientid=${$scope.clientId}`
                    }).then(function successCallback(response) {
                        $scope.topData = response.data;
                    }, function errorCallback(response) {
                        debugger;
                    });

                }

            }],

            templateUrl: '../../js/deleteClientDirective/deleteClientDirective.html'
        };
    }
);