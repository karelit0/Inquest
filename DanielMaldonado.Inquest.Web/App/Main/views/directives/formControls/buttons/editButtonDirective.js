(function () {
    var controllerId = 'app.views.directives.formControls.buttons.editButtonController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.clickButton = function () {
                if (angular.isFunction($scope.clickCallback) && angular.isFunction($scope.clickCallback())) {
                    $scope.clickCallback()($scope.entityParameter);
                    return;
                }
            };
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('editButtonDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                clickCallback: '&', //@ reads the attribute value, = provides two-way binding, & works with functions
                textButton: '=?',
                disable: '=',
                entityParameter: '=',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/views/directives/formControls/buttons/editButtonDirective.cshtml',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();