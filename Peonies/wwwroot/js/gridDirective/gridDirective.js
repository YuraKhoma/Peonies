angular.module('phonecatApp').directive('gridDirective',
    function () {
        return {
            restrict: 'E',
            
            scope: {
                id: '=',
                child: '=',
                name: '=',
                detail: '='
            },
            controller: ['$scope', '$rootScope', '$http', '$location', function MyTabsController($scope, $rootScope, $http) {
                $scope.currentPage = 1;
                $scope.nextPage = function () {
                    $scope.currentPage += 1;

                    loadMainData();
                }

                $scope.prevPage = function () {
                    if ($scope.currentPage > 1) {
                        $scope.currentPage -= 1;
                        loadMainData();
                    }
                }
               
                $scope.selectionChange = function (id, name, orders) {
                    $scope.detail = loadDetails(id);
                    debugger;
                };

                if ($scope.child == true) {
                    $scope.$on("MyEvent", function (id, name) {
                       
                        debugger;

                    });
                }

                function loadMainData() {
                    if ($scope.child != true) {
                        $http({
                            method: 'GET',
                            url: `https://localhost:44362/Client/index?page=${$scope.currentPage}`
                        }).then(function successCallback(response) {
                            $scope.topData = response.data;
                        }, function errorCallback(response) {
                            debugger;
                        });
                    }
                };

                function loadDetails(id) {
                    debugger;
                    if ($scope.child != true) {
                        $http({
                            method: 'GET',
                            url: `https://localhost:44362/Client/detail?id=${id}`
                        }).then(function successCallback(response) {
                            $scope.detail2 = response.data;
                            console.log($scope.detail2.name);
                            debugger;
                        }, function errorCallback(response) {
                            debugger;
                        });
                    }
                };

                $scope.navigateToEditClient = function (id) {
                    debugger;
                    $scope.id;
                    window.open(`https://localhost:44362/Home/GetEditClient?id=` + id);
                };

                loadMainData();
            }],
            templateUrl: '../../js/gridDirective/gridDirective.html'
        };
    }

);