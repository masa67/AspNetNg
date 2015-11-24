
(function () {
    'use strict';

    /*global angular */
    angular
        .module('LandingPage', [])
        .controller('LandingPageController', ['$scope', '$http', function ($scope, $http) {

            $http({
                method: 'GET',
                url: '/api/Dogs/Dog'
            }).then(function successCallback(response) {

            }, function errorCallback(response) {

            });
        }]);
}());