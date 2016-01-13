'use strict';

angular.module('adf.widget.US-Map', ['adf.provider'])
.config(function(dashboardProvider){
  dashboardProvider
  .widget('US-Map', {
    title: 'US Map',
    description: 'display geo info',
    templateUrl: '{widgetsPath}/US-Map/src/view.html',
    controller: 'US-MapCtrl',
    edit: {
      templateUrl: '{widgetsPath}/US-Map/src/edit.html'
    }
  });
})
.controller('US-MapCtrl', function($scope) {
  var map = new Datamap({
    element: document.getElementById('usmap'),
    scope: 'usa',
    fills: {
      'MN': '#7a0019',
      '1k': '#F44336',
      '2k': '#2196F3',
      defaultFill: '#ffcc33'
    },
    data: {
      'MN': {fillKey: 'MN'}
    }
  });

  var bombs = [
    {
      name: 'Joe 4',
      radius: 25,
      fillKey: '1k',
      latitude: 37,
      longitude: -120
    },
    {
      name: 'RDS-37',
      radius: 40,
      fillKey: '2k',
      latitude: 46,
      longitude: -94
    }
  ];
  //draw bubbles for bombs
  map.bubbles(bombs);
});
