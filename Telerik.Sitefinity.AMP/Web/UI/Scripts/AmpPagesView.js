(function () {
		"use strict";

		var ampModule = angular.module('AmpModule', []);

		ampModule.controller("AmpController", ['$scope', 'AmpService', 'ampPagesPageUrl', function ($scope, AmpService, ampPagesPageUrl) {
				$scope.loading = false;
				$scope.ampPagesPageUrl = ampPagesPageUrl;

				$scope.ampPages =  [
						{ 'Name': 'Blogs Amp Page', 'Module': 'Blog Posts' } ,
					{ 'Name': 'Events Amp Page', 'Module': 'Events' },
							{ 'Name': 'Showcases Amp Page', 'Module': 'Showcases' },
				];

				//AmpService.get().success(function (data) {
				//		$scope.loading = false;
				//		//$scope.ampPages = data;

						
				//});
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