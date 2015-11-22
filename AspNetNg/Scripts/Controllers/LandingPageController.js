
(function () {
    'use strict';

    /*global angular */
    angular
        .module('LandingPage', [])
        .controller('LandingPageController', ['$scope', function ($scope) {

            $scope.models = {
                helloAngular: 'I work!'
            };
        }]);
}());