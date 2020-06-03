(function () {
    var controllerId = 'app.views.directives.formControls.numberboxController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.localize = App.localize;
            ctrl.patternText = /^\d+$/;
            ctrl.controlId = App.newGuid();
            //ctrl.entityModel = $scope.entity;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/

            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('numberboxDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entity: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                entityHeader: '=',
                placeHolder: '=',
                helpText: '=',
                parentForm: '=',
                required: '=',
                disable: '=',
                minValue: '=?',
                maxValue: '=?',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/views/directives/formControls/numberboxDirective.cshtml',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();