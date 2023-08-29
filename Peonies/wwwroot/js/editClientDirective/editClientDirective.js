angular.module('phonecatApp').directive('editClientDirective',
    function () {
        return {
            restrict: 'E',

            scope: {
                name: '=',
                clientId: '='
            },
            controller: ['$scope', '$rootScope', '$http', function MyTabsController($scope, $rootScope, $http) {
                $scope.Edit = function () {
                    debugger;

                    $scope.ClientId;
                    $scope.name = $scope.Input

                    

                    $http({
                        method: 'PUT',
                        url: `https://localhost:44362/Client/edit?name=${$scope.name}`
                    }).then(function successCallback(response) {
                        $scope.topData = response.data;
                    }, function errorCallback(response) {
                        debugger;
                    });

                }

            }],

            templateUrl: '../../js/editClientDirective/editClientDirective.html'
        };
    }
);