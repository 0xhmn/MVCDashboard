angular.module('controller-01', ['adf'])
.controller('mainController', function ($scope, commonDataService) {

	// var structure = "3-9 (12/6-6)";
	var structure = "6-6";

	var model = {
		title: "Student Tracking System Dashboard",
		// structure: "6-6",
		rows:[
		{
			columns: [{
				widgets: [{
					modalSize: 'lg',
					fullScreen: false,
					type: "baseWidget",
					title: "BaseWidget Title"
				}

				]
			}]
		}]
			
	}

	$scope.data2 = commonDataService.data;

	$scope.model = model;
	// $scope.structure = structure;

	})