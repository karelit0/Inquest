(function () {
    var app = angular.module('app');

    app.factory('services.common.sorterExpresionFactory', [
        function () {

            /******************************  Builders  ********************************************************************/
            var sorterExpresionFactory = function (_propertyName, _ascendig) {
                this.propertyName = _propertyName;
                this.ascendig = _ascendig;
            };
            /******************************  End  *************************************************************************/
            return sorterExpresionFactory;
        }
    ]);
})();
