angular.module('sample', [
        'adf', 'adf.structures.base', 'adf.widget.clock', 'adf.widget.version', 'controller-01'
		, 'adf.widget.sampleWidget', 'adf.widget.baseWidget'
])

.factory("commonDataService", function ($rootScope) {
	var scope = $rootScope.$new(true);
	scope.data = { text: "default term" };
	return scope;
});