(function (window, undefined) {


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
				// global data variable
				$scope.data2 = commonDataService.data;

				function makeDistinctArray(responsArray) {
					var idArray = [];
					var nameArray = [];
					var applicationNumber = [];
					for (var i = 0; i < responsArray.length; i++) {
						idArray.push(responsArray[i].id);
						nameArray.push(responsArray[i].name);
						applicationNumber.push(responsArray[i].numberOfApplications);
					}
					var result = { ids: idArray, names: nameArray, applications: applicationNumber }
					return result;
				}

				function drawChart(responseArray) {
					var data = {
						labels: responseArray.names,

						series: [responseArray.applications]
					}
					var options = {
						width: 500,
						height: 300
					};

					new Chartist.Bar('.ct-chart', data, options);
				}

				// watch program for any change
				$scope.$watch('data2.program', function () {
					if ($scope.data2.program == "default") {
						$scope.programSelected = false;
					} else {
						$scope.programSelected = true;
						var url = "http://ultraviolet.csom.umn.edu/mvcdashboard/counterApplication/" + $scope.data2.program;
						$http.get(url).then(function (res) {

							$scope.numberOfApplications = res.data;
							console.table(makeDistinctArray(res.data));
							var responseArray = makeDistinctArray(res.data);
							drawChart(responseArray);

						});
					}
				}, true);




			}
		]);

//angular.module("adf.widget.sampleWidget").run(["$templateCache", function ($templateCache) {
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/edit.html", "<form role=form><div class=form-group><label for=sample>Sample</label> <input type=text class=form-control id=sample ng-model=config.sample placeholder=\"Enter sample\"></div></form>");
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/view.html", "<div><h1>Widget view</h1><p>Content of {{config.sample}}</p></div>");
	//}]);

})(window);