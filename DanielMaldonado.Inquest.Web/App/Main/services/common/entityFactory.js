(function () {
    var app = angular.module('app');

    app.factory('services.common.entityFactory', [
        function () {

            /******************************  Builders  ********************************************************************/
            var entityFactory = function () {
                this.entity = new Object();
                this.backupEntity = null;
                this.editing = false;
            };
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            entityFactory.prototype.selectEntity = function (entitySelected) {
                this.entity = entitySelected;
                this.backupEntity = angular.copy(entitySelected);
            };
            //
            entityFactory.prototype.reverChanges = function () {
                if (this.backupEntity != null)
                    this.entity = angular.copy(this.backupEntity);
                else
                    this.entity = new Object();
            };
            //
            entityFactory.prototype.editEntity = function () {
                this.isEditing = true;
            };
            //
            entityFactory.prototype.cancelEdit = function () {
                this.isEditing = false;
            };
            //
            entityFactory.prototype.isEditing = function () {
                return (this.backupEntity == null);
            };
            /******************************  End  *************************************************************************/
            return entityFactory;
        }
    ]);
})();
