angular.module('controller-01', ['adf'])
.controller('mainController', function ($scope, commonDataService) {

	// var structure = "3-9 (12/6-6)";
	// var structure = "6-6";

	var model = {
		title: "Student Tracking System Dashboard",
		structure: "6-6",
		rows:[
		{
			columns: [{
				styleClass: "col-md-6",
				widgets: [{
					modalSize: 'lg',
					fullScreen: false,
					type: "baseWidget",
					title: "Base Widget"
				}]
			}, {
				styleClass: "col-md-6",
				widgets: [{
					modalSize: 'lg',
					fullScreen: false,
					type: "sampleWidget",
					title: "Simple Query Widget"
				},
				{
					modalSize: 'lg',
					fullScreen: false,
					type: "counterWidget",
					title: "Counter Widget"
				}]
			}]
		}]
			
	}

	$scope.data2 = commonDataService.data;

	$scope.model = model;
	$scope.collapsible = false;
	$scope.maximizable = false;
	// $scope.structure = structure;

})

