(function () {
		"use strict";

		var ampModule = angular.module('AmpModule', []);

		ampModule.controller("AmpController", ['$scope', '$location', '$routeParams', 'AmpService', 'ampPagesPageUrl', function ($scope, $location, $routeParams, AmpService, ampPagesPageUrl) {
				$scope.loading = true;
				$scope.ampPagesPageUrl = ampPagesPageUrl;

				AmpService.get().success(function (data) {
						$scope.loading = false;
						$scope.ampPages = data;
				});

				$scope.loadCreatePage = function () {
						$location.path('/Sitefinity/Administration/AMP-AmpPages/Details/' + $routeParams.id);
				};

				$scope.cancel = function() {
						$location.path('/Sitefinity/Administration/AMP-AmpPages');
				}
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