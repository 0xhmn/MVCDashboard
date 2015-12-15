angular.module('controller-01', ['adf'])
.controller('mainController', function ($scope) {

	//var structure = "3-9 (12/6-6)";
	var structure = "6-6";

	var model = {
		title: "Sample Dashboard Model"
			
	}
	$scope.model = model;
	$scope.structure = structure;

	})