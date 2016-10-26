(function () {
		"use strict";

		var ampModule = angular.module('AmpModule', []);

		ampModule.controller("AmpController", ['$scope', 'AmpService', function ($scope, AmpService) {
				$scope.loading = true;

				AmpService.get().success(function (data) {
						$scope.loading = false;
						$scope.ampPages = data;
				});
		}]);

		ampModule.factory('AmpService', ['$http', 'ampServiceUrl', function ($http, ampServiceUrl) {
				var service = {
						get: function () {
								return $http.get(ampServiceUrl);
						}
				};

				return service;
		}]);
})();