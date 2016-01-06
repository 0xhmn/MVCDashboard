(function (window, undefined) {
	'use strict';


	angular.module('adf.widget.counterWidget', ['adf.provider'])
		.config([
			"dashboardProvider", function(dashboardProvider) {
				dashboardProvider
					.widget('counterWidget', {
						title: 'Counter Widget',
						description: 'a counter widget',
						templateUrl: "Widgets/adf-widget-counter/src/view.html",
						controller: "counterController",
						edit: {
							templateUrl: "Widgets/adf-widget-counter/src/edit.html"
						}
					});
			}
		])

		.controller('counterController', [
			"$http", "$scope", "commonDataService", function ($http, $scope, commonDataService) {

				$scope.data2 = commonDataService.data;
				$scope.$watch('data2', function() {
					if ($scope.data2.program !== "default") {
						var url = "http://ultraviolet.csom.umn.edu/mvcdashboard/counterApplication/" + $scope.data2.program;
						$http.get(url).then(function (res) {
							console.table(res.data)
							$scope.numberOfApplications = res.data;
						})
					}

				}, true);

			}
		]);

//angular.module("adf.widget.sampleWidget").run(["$templateCache", function ($templateCache) {
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/edit.html", "<form role=form><div class=form-group><label for=sample>Sample</label> <input type=text class=form-control id=sample ng-model=config.sample placeholder=\"Enter sample\"></div></form>");
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/view.html", "<div><h1>Widget view</h1><p>Content of {{config.sample}}</p></div>");
	//}]);

})(window);