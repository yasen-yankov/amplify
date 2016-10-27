(function () {
	"use strict";

	var ampPageModule = angular.module('AmpPageModule', ["kendo.directives"]);

	ampPageModule.controller("AmpPageController", ['$scope', 'AmpService', 'ampPageId', 'ampGroupPageUrl', 'isCreateMode', function ($scope, AmpService, ampPageId, ampGroupPageUrl, isCreateMode) {
		$scope.ampPageId = ampPageId;
		$scope.ampGroupPageUrl = ampGroupPageUrl;
		$scope.isCreateMode = (isCreateMode === "true");

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
				$scope.addonFolderExists = false;

				if (data) {
					$scope.ampPage = data[0];
				}
			});
		};

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
			AmpService.post($scope.ampPage);
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
	}]);

	ampPageModule.factory('AmpService', ['$http', 'ampServiceUrl', 'ampPageId', function ($http, ampServiceUrl, ampPageId) {
		var service = {
			get: function () {
				return $http.get(ampServiceUrl, { params: { id: ampPageId } });
			},
			post: function (data) {
				return $http.post(ampServiceUrl + "/" + ampPageId, data);
			}
		};

		return service;
	}]);
})();