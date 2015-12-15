(function(window, undefined) {'use strict';

angular.module('adf.widget.clock', ['adf.provider'])
  .config(["dashboardProvider", function(dashboardProvider){
    dashboardProvider
      .widget('clock', {
        title: 'Clock',
        description: 'Displays date and time',
        templateUrl: '{widgetsPath}/clock/src/view.html',
        controller: 'clockController',
        controllerAs: 'clock',
        config: {
          timePattern: 'HH:mm:ss',
          datePattern: 'YYYY-MM-DD'
        },
        edit: {
          templateUrl: '{widgetsPath}/clock/src/edit.html'
        }
      });
  }])
  .controller('clockController', ["$scope", "$interval", "config", function($scope, $interval, config){
    var clock = this;

    function setDateAndTime(){
      var d = new moment();
      clock.time = d.format(config.timePattern);
      clock.date = d.format(config.datePattern);
    }

    setDateAndTime();

    // refresh every second
    var promise = $interval(setDateAndTime, 1000);

    // cancel interval on scope destroy
    $scope.$on('$destroy', function(){
      $interval.cancel(promise);
    });
  }]);

angular.module("adf.widget.clock").run(["$templateCache", function($templateCache) {$templateCache.put("{widgetsPath}/clock/src/edit.html","<form role=form><div class=form-group><label for=time>Time pattern</label> <input type=text class=form-control id=time ng-model=config.timePattern></div><div class=form-group><label for=date>Date pattern</label> <input type=text class=form-control id=date ng-model=config.datePattern></div><p class=text-info>For the list of possible patterns, please have a look at <a target=_blank href=\"http://momentjs.com/docs/#/displaying/\">moment.js documentation</a></p></form>");
$templateCache.put("{widgetsPath}/clock/src/view.html","<div class=clock><div class=clock-time>{{clock.time}}</div><div class=clock-date>{{clock.date}} </div></div>");}]);})(window);