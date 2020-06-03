(function () {
    var controllerId = 'app.views.directives.formControls.uiSelectController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.initialize = function () {
                ctrl.setValidators();
            };
            //
            ctrl.onSelectItem = function (item, model) {
                $scope.entity = item;
                //ctrl.checkRequired();

                if (angular.isFunction($scope.onSelectItem) && angular.isFunction($scope.onSelectItem())) {
                    $scope.onSelectItem()($scope.entity);
                    return;
                }
            };
            //
            ctrl.checkRequired = function () {
                if ($scope.required) {
                    if (angular.isObject($scope.entity))
                        $scope.parentForm[ctrl.controlId].$valid = true;
                }
            };
            //
            ctrl.setValidators = function () {
                if ($scope.required) {
                    $scope.parentForm[ctrl.controlId].$validators.uiSelectRequired = function (modelValue, viewValue) {
                        var determineVal;
                        if (angular.isArray(modelValue)) {
                            determineVal = modelValue;
                        } else if (angular.isArray(viewValue)) {
                            determineVal = viewValue;
                        } else if (angular.isObject(modelValue)) {
                            determineVal = angular.equals(modelValue, {}) ? [] : ['true'];
                        } else if (angular.isObject(viewValue)) {
                            determineVal = angular.equals(viewValue, {}) ? [] : ['true'];
                        } else {
                            return false;
                        }

                        return determineVal.length > 0;
                    };
                }
            };
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('uiSelectDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entity: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                onSelectItem: '&',
                list: '=',
                propertyName: '@',
                entityHeader: '@',
                placeHolder: '@',
                helpText: '@',
                parentForm: '=',
                required: '=',
                disable: '=',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/views/directives/formControls/uiSelectDirective.cshtml',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {

            }
        }
    });

})();