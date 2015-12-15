(function (window, undefined) {
	'use strict';


	angular.module('adf.widget.sampleWidget', ['adf.provider'])
	  .config(["dashboardProvider", function (dashboardProvider) {
	  	dashboardProvider
		  .widget('sampleWidget', {
		  	title: 'Sample Widget',
		  	description: 'this is a sample widgettt',
		  	templateUrl: "Widgets/adf-widget-sample/src/view.html",
		  	controller: "sampleController",
			controllerAs: "sampleCtrl",
		  	edit: {
		  		templateUrl: "Widgets/adf-widget-sample/src/edit.html"
		  	}
		  });
	  }])

	.controller('sampleController', ["$scope", function($scope) {
		$scope.test = "another test";
		}])


	//angular.module("adf.widget.sampleWidget").run(["$templateCache", function ($templateCache) {
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/edit.html", "<form role=form><div class=form-group><label for=sample>Sample</label> <input type=text class=form-control id=sample ng-model=config.sample placeholder=\"Enter sample\"></div></form>");
	//	$templateCache.put("{widgetsPath}/sampleWidget/src/view.html", "<div><h1>Widget view</h1><p>Content of {{config.sample}}</p></div>");
	//}]);

})(window);