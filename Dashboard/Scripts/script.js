angular.module('sample', [
        'adf', 'adf.structures.base', 'adf.widget.clock', 'adf.widget.version'
		, 'controller-01'
		, 'adf.widget.sampleWidget'
		, 'adf.widget.baseWidget'
		, 'adf.widget.counterWidget'
])

.factory("commonDataService", function ($rootScope) {
	var scope = $rootScope.$new(true);
	scope.data = { program: "default", term: "default"};
	return scope;
});