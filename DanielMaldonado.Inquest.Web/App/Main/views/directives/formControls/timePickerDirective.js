(function () {
    var controllerId = 'app.views.directives.formControls.timePickerController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            ctrl.hourStep = 1;
            ctrl.minStep = 15;
            ctrl.isMeridian = true;
            ctrl.minTime = null;
            ctrl.maxTime = null;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            ctrl.initialize = function () {
                ctrl.minTime = new Date(2012, 01, 01);
                ctrl.minTime.setHours(7);
                ctrl.minTime.setMinutes(0);

                ctrl.maxTime = new Date(2012, 01, 01);
                ctrl.maxTime.setHours(17);
                ctrl.maxTime.setMinutes(0);

                if (!App.isValidObject($scope.entity)) {
                    $scope.entity = ctrl.minTime;
                }
            };
            //
            ctrl.changed = function () {
                $scope.entity.setYear(2012);
                $scope.entity.setMonth(01);
                $scope.entity.setDate(01);

                if ($scope.entity < ctrl.minTime) {
                    $scope.entity = ctrl.maxTime;
                    return;
                }

                if ($scope.entity > ctrl.maxTime) {
                    $scope.entity = ctrl.minTime;
                    return;
                }
            };
            /******************************  End  *************************************************************************/
            /******************************  Initialize  ******************************************************************/
            ctrl.initialize();
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('timePickerDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entity: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                entityHeader: '@',
                placeHolder: '@',
                helpText: '@',
                parentForm: '=',
                required: '=',
                disable: '=',
                minTime: '=',
                maxTime: '=',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/views/directives/formControls/timePickerDirective.cshtml',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
                if (attr.minTime) {

                }

                if (attr.maxTime) {

                }
            }
        }
    });

})();