
(function () {
    'use strict';

    /*global angular */
    angular
        .module('LandingPage', [])
        .controller('LandingPageController', ['$scope', '$http', function ($scope, $http) {

            $http({
                method: 'POST',
                url: '/api/Dogs/Dog',
                data: {
                    DogId: 1
                }
            }).then(function successCallback(response) {

            }, function errorCallback(response) {

            });
        }]);
}());