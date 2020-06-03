(function () {
    var app = angular.module('app');

    app.factory('services.common.columInfoFactory', [
        function () {

            /******************************  Builders  ********************************************************************/
            var columInfoFactory = function (headerLabel, pathProperty, pathEntity, propertyType) {
                this.headerLabel = headerLabel;
                this.pathProperty = pathProperty;
                this.pathEntity = pathEntity;
                this.propertyType = propertyType;
            }
            /******************************  End  *************************************************************************/

            return columInfoFactory;

        }
    ]);
})();
