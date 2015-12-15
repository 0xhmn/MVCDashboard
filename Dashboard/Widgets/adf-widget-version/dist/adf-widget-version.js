(function(window, undefined) {'use strict';

angular.module('adf.widget.version', ['adf.provider'])
  .config(["dashboardProvider", function(dashboardProvider){
    dashboardProvider
      .widget('version', {
        title: 'Version',
        description: 'Displays the angular-dashboard-framework',
        template: 'angular-dashboard-framework: {{version}}',
        controller: ["$scope", "adfVersion", function($scope, adfVersion){
          var version = adfVersion;
          if (version.indexOf('<<') >= 0){
            version = 'unknown';
          }
          $scope.version = version;
        }],
      });
  }]);
})(window);