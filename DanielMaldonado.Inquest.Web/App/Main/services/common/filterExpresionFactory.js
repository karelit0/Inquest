(function () {
    var app = angular.module('app');

    app.factory('services.common.filterExpresionFactory', [
        function () {

            /******************************  Builders  ********************************************************************/
            var filterExpresionFactory = function (_union, _propertyType, _operation, _propertyName, _value) {
                this.union = _union;
                this.propertyType = _propertyType;
                this.operation = _operation;
                this.propertyName = _propertyName;
                this.value = _value;
            };
            /******************************  End  *************************************************************************/
            return filterExpresionFactory;
        }
    ]);
})();
