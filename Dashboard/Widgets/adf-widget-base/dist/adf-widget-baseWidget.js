(function (window, undefined) {
	'use strict';


	angular.module('adf.widget.baseWidget', ['adf.provider'])
		.config([
			"dashboardProvider", function(dashboardProvider) {
				dashboardProvider
					.widget('baseWidget', {
						title: 'Base Widget',
						description: 'base widget for all the queries',
						templateUrl: "Widgets/adf-widget-base/src/view.cshtml",
						controller: "baseWidgetController",
						controllerAs: "baseWidCtrl",
						edit: {
							templateUrl: "Widgets/adf-widget-base/src/edit.html"
						}
					});
			}
		])
		.controller('baseWidgetController',
			["$http", "$scope", "commonDataService", function($http, $scope, commonDataService) {

			  $scope.data1 = commonDataService.data;


				// getting the terms
				var getProgramReq = {
					method: 'GET',
					url: "programs/",
					headers: { 'Content-Type': 'application/json' }
				}

				$http(getProgramReq).then(function(res) {
					$scope.programs = res.data;
				});

				$scope.generateTerms = function(programId) {
					var url = "terms/" + programId;
					$http.get(url).then(function(res) {
						if (res.data.length === 0) {
							$scope.terms = [{ id: -1, name: "Does not have a term" }];
						} else {
							$scope.terms = res.data;
						}
					});
				}
			}
		]);


//angular.module("adf.widget.sampleWidget").run(["$templateCache", function ($templateCache) {
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/edit.html", "<form role=form><div class=form-group><label for=sample>Sample</label> <input type=text class=form-control id=sample ng-model=config.sample placeholder=\"Enter sample\"></div></form>");
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/view.html", "<div><h1>Widget view</h1><p>Content of {{config.sample}}</p></div>");
	//}]);

})(window);
