(function (window, undefined) {


	angular.module('adf.widget.timelineWidget', ['adf.provider'])
		.config([
			"dashboardProvider", function(dashboardProvider) {
				dashboardProvider
					.widget('timelineWidget', {
						title: 'Timeline Widget',
						description: 'a timeline widget',
						templateUrl: "Widgets/adf-widget-timeline/src/view.html",
						controller: "timelineController",
						edit: {
							templateUrl: "Widgets/adf-widget-timeline/src/edit.html"
						}
					});
			}
		])

		.controller('timelineController', [
			"$http", "$scope", "commonDataService", function ($http, $scope, commonDataService) {

				// global data variable
			  $scope.data2 = commonDataService.data;

			  // startDate":"2014-02-01T00:00:00","endDate":"2014-08-31T00:00:00"
        function dateDeserializer(dateString) {
          var date = "2014-12-30T00:00:00";
          var regex = /(\d\d\d\d)-(\d\d)-(\d\d)/g;
          var match = regex.exec(date);
          console.log(match)
          console.log(new Date(date))
          return new Date(match[1]);
        }

        $scope.standardDateMaker = function(date) {
          return date.slice(0, 10);
        }

			  // Generating Data from Response
			  function makeGoogleChartArray(responsArray) {
			    var result = [];
			    for (var i = 0; i < responsArray.length; i++) {
			      var pair = [];
              pair.push(responsArray[i].id);
              pair.push(responsArray[i].name);
              pair.push(new Date(responsArray[i].startDate));
              pair.push(new Date(responsArray[i].endDate));
              result.push(pair);
           }
			    return result;
			  }



        // Generate Google Chart
				function drawChart(responseData) {
				  var container = document.getElementById('timeline');
				  var chart = new google.visualization.Timeline(container);
				  var dataTable = new google.visualization.DataTable();

				  dataTable.addColumn({ type: 'string', id: 'Term' });
				  dataTable.addColumn({ type: 'string', id: 'Name' });
				  dataTable.addColumn({ type: 'date', id: 'Start' });
				  dataTable.addColumn({ type: 'date', id: 'End' });
				  dataTable.addRows(responseData);

				  var options = {
				    timeline: {
				      rowLabelStyle: { fontName: 'Helvetica', fontSize: 11, color: '#603913' },
				      barLabelStyle: { fontSize: 11 }
				}
				  };
				  chart.draw(dataTable, options);
				}

        var setHeight = function(h) {
          var myEl = angular.element(document.querySelector('#timeline'));
          var hString = h + 'px';
          myEl.css('height', hString);
        }

        var tableBuilder = function(data) {

        }

			  // getting the terms
				$scope.$watch('data2.programId', function () {
	        if ($scope.data2.programId === -1) {
	          $scope.programSelected = false;
	        } else {
	          $scope.programSelected = true;
	          var url = "timeline/" + $scope.data2.programId;
	          $http.get(url).then(function(res) {
	            $scope.terms = res.data;
              //// calculating the height
	            var h = 50;    // min height
	            var numOfRows = makeGoogleChartArray(res.data).length;
	            setHeight(h + (numOfRows*38));  // using the font-size of 11px
	            drawChart(makeGoogleChartArray(res.data));
	          });
	        }
	      });

	    }
		]);

//angular.module("adf.widget.sampleWidget").run(["$templateCache", function ($templateCache) {
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/edit.html", "<form role=form><div class=form-group><label for=sample>Sample</label> <input type=text class=form-control id=sample ng-model=config.sample placeholder=\"Enter sample\"></div></form>");
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/view.html", "<div><h1>Widget view</h1><p>Content of {{config.sample}}</p></div>");
	//}]);

})(window);
