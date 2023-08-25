angular.module('phonecatApp').directive('gridDirective',
    function () {
        return {
            restrict: 'E',
            
            scope: {
                id: '=',
                child: '=',
                name: '=',
            },
            controller: ['$scope', '$rootScope', '$http', function MyTabsController($scope, $rootScope, $http) {

                $scope.selectionChange = function (id, name, orders) {
                    // to do - selection change

                    debugger;

                    $scope.detail = 'Client name: ' + name + ' Client id: ' + id;
                    $scope.orders = orders;
                };

                if ($scope.child == true) {
                    $scope.$on("MyEvent", function (id, name) {
                       
                        debugger;

                    });
                }

                if ($scope.child != true) {
                    $http({
                        method: 'GET',
                        url: 'https://localhost:44362/Client/index'
                    }).then(function successCallback(response) {
                        $scope.topData = response.data;
                    }, function errorCallback(response) {
                        debugger;
                    });
                    /*
                    let data = {
                        'a': 1
                    }
                    $rootScope.$broadcast("MyEvent", data);
                    $rootScope.$emit("MyEvent", data);
                    */
                }
            }],
            templateUrl: '../../js/gridDirective/gridDirective.html'
        };
    }

);