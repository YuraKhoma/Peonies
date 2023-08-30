angular.module('phonecatApp').directive('addClientDirective',
    function () {
        return {
            restrict: 'E',

            scope: {
                name: '='
            },
            controller:  ['$scope', '$rootScope', '$http', function MyTabsController($scope, $rootScope, $http) {
                $scope.Add = function () {

                    $scope.name = $scope.Input

                    debugger;

                    $http({
                        method: 'POST',
                        url: `https://localhost:44362/Client/add?name=${$scope.name}`
                    }).then(function successCallback(response) {
                        $scope.topData = response.data;
                    }, function errorCallback(response) {
                        debugger;
                    });

                    $scope.Input = null

                    alert("Item added. You can close the tab");
                }
            
            }],

        templateUrl: '../../js/addClientDirective/addClientDirective.html'
        };
    }
);