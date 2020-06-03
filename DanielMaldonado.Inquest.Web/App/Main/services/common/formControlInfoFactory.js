(function () {
    var app = angular.module('app');

    app.factory('services.common.formControlInfoFactory', [
        function () {

            /******************************  Builders  ********************************************************************/
            var formControlInfoFactory = function (entity, inputType, entityHeader, placeHolder, helpText, parentForm, enable, required, minValue, maxValue) {
                this.entity = entity;
                this.inputType = inputType;
                this.entityHeader = entityHeader;
                this.placeHolder = placeHolder;
                this.helpText = helpText;
                this.parentForm = parentForm;
                this.enable = enable;
                this.required = required;
                this.minValue = minValue;
                this.maxValue = maxValue;
            }
            /******************************  End  *************************************************************************/

            return formControlInfoFactory;

        }
    ]);
})();
