(function () {
		"use strict";

		var ampModule = angular.module('AmpModule', []);

		ampModule.controller("AmpController", ['$scope', 'AmpService', 'ampPagesPageUrl', function ($scope, AmpService, ampPagesPageUrl) {
				$scope.loading = true;
				$scope.ampPagesPageUrl = ampPagesPageUrl;

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