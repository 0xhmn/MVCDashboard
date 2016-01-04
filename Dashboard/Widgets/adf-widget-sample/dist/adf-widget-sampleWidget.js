(function (window, undefined) {
	'use strict';


	angular.module('adf.widget.sampleWidget', ['adf.provider'])
		.config([
			"dashboardProvider", function(dashboardProvider) {
				dashboardProvider
					.widget('sampleWidget', {
						title: 'Simple Query Test',
						description: 'this is a sample widget',
						templateUrl: "Widgets/adf-widget-sample/src/view.html",
						controller: "sampleController",
						controllerAs: "sampleCtrl",
						edit: {
							templateUrl: "Widgets/adf-widget-sample/src/edit.html"
						}
					});
			}
		])
		.controller('sampleController', [
			"$http", "$scope", "commonDataService", function ($http, $scope, commonDataService) {

				$scope.title = "Sample Query Widget";

				var getReq = {
					method: 'GET',
					url: "http://ultraviolet.csom.umn.edu/mvcdashboard/test",
					headers: { 'Content-Type': 'application/json' }
				}

				$http(getReq).then(function (res) {
					$scope.name = res.data.Name;
					$scope.id = res.data.Id;
					$scope.term = res.data.Term;

				});

				$scope.sendGetReq = function() {
					$http(getReq).then(function (res) {
						console.log("getting the response:");
						console.table(res);
					});
				}

				$scope.data2 = commonDataService.data;

			}
		]);


//angular.module("adf.widget.sampleWidget").run(["$templateCache", function ($templateCache) {
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/edit.html", "<form role=form><div class=form-group><label for=sample>Sample</label> <input type=text class=form-control id=sample ng-model=config.sample placeholder=\"Enter sample\"></div></form>");
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/view.html", "<div><h1>Widget view</h1><p>Content of {{config.sample}}</p></div>");
	//}]);

})(window);