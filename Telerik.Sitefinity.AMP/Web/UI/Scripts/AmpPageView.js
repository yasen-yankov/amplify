﻿(function () {
	"use strict";

	var ampPageModule = angular.module('AmpPageModule', ["kendo.directives"]);

	ampPageModule.controller("AmpPageController", ['$scope', '$window', 'AmpService', 'AmpConfigService', 'ampPageId', 'ampGroupPageUrl', 'isCreateMode', function ($scope, $window, AmpService, AmpConfigService, ampPageId, ampGroupPageUrl, isCreateMode) {
		$scope.ampPageId = ampPageId;
		$scope.ampGroupPageUrl = ampGroupPageUrl;
		$scope.isCreateMode = (isCreateMode.toLowerCase() === "true");

		var loadAmpConfig = function () {
			AmpConfigService.get().success(function (data) {
				$scope.initialLoading = false;
				$scope.loading = false;
				$('body').removeClass('sfLoadingTransition');

				$scope.ampConfig = data;
				$scope.componentTypes = getComponentArray($scope.ampConfig.AmpComponentTypes);
				$scope.componentTypes.push({ "key": "PlainText", "value": "" });
			}).error(function (data, status) {
				$scope.initialLoading = false;
				$scope.loading = false;
				$('body').removeClass('sfLoadingTransition');

				if (data) {
					$scope.ampConfig = data;
					$scope.componentTypes = getComponentArray($scope.ampConfig.AmpComponentTypes);
					$scope.componentTypes.unshift({ "key": "PlainText", "value": "" });
				}
			});
		};

		var getComponentArray = function (obj) {
			var arr = [];
			for (var key in obj) {
				if (obj.hasOwnProperty(key)) {
					var keyValue = { "key": key, "value": obj[key] };
					arr.push(keyValue);
				}
			};

			return arr;
		}

		var loadAmpPage = function () {
			AmpService.get().success(function (data) {
				$scope.initialLoading = false;
				$scope.loading = false;
				$('body').removeClass('sfLoadingTransition');

				$scope.ampPage = data[0];
			}).error(function (data, status) {
				$scope.initialLoading = false;
				$scope.loading = false;
				$('body').removeClass('sfLoadingTransition');

				if (data) {
					$scope.ampPage = data[0];
				}
			});
		};

		$scope.loading = true;
		loadAmpConfig();

		if (!$scope.isCreateMode) {
			$scope.loading = true;

			loadAmpPage();
		}

		$scope.sortFieldListItems = function (e) {
			var elementOldIndex = $scope.ampPage.Fields[e.oldIndex];
			var elementNewIndex = $scope.ampPage.Fields[e.newIndex];

			elementOldIndex.Ordinal = e.newIndex;
			elementNewIndex.Ordinal = e.oldIndex;

			$scope.ampPage.Fields.splice(e.oldIndex, 1);
			$scope.ampPage.Fields.splice(e.newIndex, 0, elementOldIndex);
		};

		$scope.updateUrlName = function (title) {
			$scope.ampPage.UrlName = title.toLowerCase().replace(/[^\w\-\!\$\'\(\)\=\@\d_]+/g, '-');
		};

		$scope.fieldItemClicked = function (fieldItem) {
			$scope.selectedField = fieldItem;
		};

		$scope.save = function () {
			AmpService.post($scope.ampPage).success(function (data) {
				$window.location.href = $scope.ampGroupPageUrl;
			});
		};

		$scope.create = function () {
			AmpService.put($scope.ampPage).success(function (data) {
				$window.location.href = $scope.ampGroupPageUrl;
			});
		};

		$scope.sortableOptions = {
			hint: function (element) {
				return $('<div class="sf-backend-wrp"><div class="list-group-item list-group-item-multiselect list-group-item-draggable list-group-item-hint">' +
							element.html() +
						'</div></div>');
			},
			placeholder: function (element) {
				return $('<div class="list-group-item list-group-item-placeholder"></div>');
			},
			handler: ".handler",
			axis: "y"
		};

		$scope.selectFields = function () {
			$scope.selectFieldsDialog.center();
			$scope.selectFieldsDialog.wrapper[0].style.top = "50px";
			$scope.selectFieldsDialog.open();
		};

		$scope.cancelFieldSelection = function () {
			$scope.includeContent = false;
			$scope.selectFieldsDialog.close();
		};
	}]);

	ampPageModule.factory('AmpService', ['$http', 'ampServiceUrl', 'ampPageId', function ($http, ampServiceUrl, ampPageId) {
		var service = {
			get: function () {
				return $http.get(ampServiceUrl, { params: { id: ampPageId } });
			},
			post: function (data) {
				return $http.post(ampServiceUrl + "/" + ampPageId, data);
			},
			put: function (data) {
				return $http.put(ampServiceUrl, data);
			}
		};

		return service;
	}]);

	ampPageModule.factory('AmpConfigService', ['$http', 'ampConfigServiceUrl', function ($http, ampConfigServiceUrl) {
		var service = {
			get: function () {
				return $http.get(ampConfigServiceUrl);
			}
		};

		return service;
	}]);
})();