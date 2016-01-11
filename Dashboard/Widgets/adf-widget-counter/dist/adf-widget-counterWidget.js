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

				function makeGoogleChartArray(responsArray) {
					var result = [];
					for (var i = 0; i < responsArray.length; i++) {
						var pair = [];
						pair.push(responsArray[i].name);
						pair.push(responsArray[i].numberOfApplications);
						result.push(pair);
					}
					return result;
				}

        // Chartist Chart - replaced by Google Chart / hidden by ng-hide
				function drawChartOne(responseArray) {
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


				function drawChart(responseData) {
					// Create the data table.
					var data = new google.visualization.DataTable();
					data.addColumn('string', 'Topping');
					data.addColumn('number', 'Slices');
					data.addRows(responseData);
					// Set chart options
					var options = {
						//'title': 'Program Counter Chart',
						'width': 500,
						'height': 350,
						legend: { position: 'right', textStyle: { color: 'gray', fontSize: 12 } },
						chartArea: { left: 20, top: 20, width: '100%', height: '100%' }
					};
					//// Instantiate and draw our chart, passing in some options.
					var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
					chart.draw(data, options);
				}



				//// watch program for any change
				$scope.$watch('data2.programId', function () {
					if ($scope.data2.programId === -1) {
						$scope.programSelected = false;
					} else {
						$scope.programSelected = true;
						var url = "counterApplication/" + $scope.data2.programId;
						$http.get(url).then(function (res) {

							$scope.numberOfApplications = res.data;
							// console.log(makeDistinctArray(res.data));
							// console.log(makeGoogleChartArray(res.data));

							//// draw the fist chart
							var responseArray = makeDistinctArray(res.data);
							drawChartOne(responseArray);

							drawChart(makeGoogleChartArray(res.data));
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
