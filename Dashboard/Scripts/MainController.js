angular.module('sample-01', ['adf'])
.controller('sampleCtrl', function ($scope) {

	var structure = "3-9 (12/6-6)";

		var model = {
			title: "Sample Dashboard Model"
			
		}
		$scope.model = model;
		$scope.structure = structure;

	})