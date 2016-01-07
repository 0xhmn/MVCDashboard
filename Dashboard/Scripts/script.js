angular.module('sample', [
        'adf', 'adf.structures.base', 'adf.widget.clock'
		, 'controller-01'
		, 'adf.widget.sampleWidget'
		, 'adf.widget.baseWidget'
		, 'adf.widget.counterWidget'
])

.factory("commonDataService", function ($rootScope) {
	var scope = $rootScope.$new(true);
	scope.data = { programId: -1, termId: -1 };
	return scope;
});