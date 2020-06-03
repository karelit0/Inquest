(function () {
    var app = angular.module('app');

    app.service('services.common.enumService', [
        '$q',
        'abp.services.app.enumService',
        function ($q, enumService) {
            service = this;
            /******************************  Initialize  ******************************************************************/
            service.initialize = function () {
                service.getEnumList(service.enumNameList.fieldAttributeType);
                service.getEnumList(service.enumNameList.fieldInputType);
            };
            /******************************  End  *************************************************************************/
            /******************************  Enum Localization List  ******************************************************/
            service.enumList = new Object();
            service.enumNameList = new Object();
            service.enumNameList.fieldAttributeType = 'FieldAttributeType';
            service.enumNameList.fieldInputType = 'FieldInputType';
            /******************************  End  *************************************************************************/
            /******************************  formControlTypeEnum  *********************************************************/
            service.formControlTypeEnum = new Object();
            service.formControlTypeEnum.text = 0;
            service.formControlTypeEnum.numeric = 1;
            /******************************  End  *************************************************************************/
            /******************************  FieldAttributeType  **********************************************************/
            service.fieldAttributeType = new Object();
            service.fieldAttributeType.mandatory = 0;
            service.fieldAttributeType.noMandatory = 1;
            service.fieldAttributeType.hidden = 2;
            /******************************  End  *************************************************************************/
            /******************************  ExpresionFilter  *************************************************************/
            service.expresionFilter = new Object();

            service.expresionFilter.unionFilter = new Object();
            service.expresionFilter.unionFilter.or = 0;
            service.expresionFilter.unionFilter.and = 1;

            service.expresionFilter.propertyType = new Object();
            service.expresionFilter.propertyType.guid = 0;
            service.expresionFilter.propertyType.text = 1;
            service.expresionFilter.propertyType.int = 2;
            service.expresionFilter.propertyType.decimal = 3;
            service.expresionFilter.propertyType.dateTime = 4;
            service.expresionFilter.propertyType.bool = 5;

            service.expresionFilter.optionFilter = new Object();
            service.expresionFilter.optionFilter.contains = 0;
            service.expresionFilter.optionFilter.endsWith = 1;
            service.expresionFilter.optionFilter.equals = 2;
            service.expresionFilter.optionFilter.greaterThan = 3;
            service.expresionFilter.optionFilter.greaterThanOrEqual = 4;
            service.expresionFilter.optionFilter.lessThan = 5;
            service.expresionFilter.optionFilter.lessThanOrEqual = 6;
            service.expresionFilter.optionFilter.notEqual = 7;
            service.expresionFilter.optionFilter.startsWith = 8;
            /******************************  End  *************************************************************************/
            /******************************  Enum Localization  ***********************************************************/
            //
            service.getEnumLocalization = function (enumType, enumValue) {
                var result = '';
                if (!angular.isArray(service.enumList[enumType])) {
                    var promise = service.getEnumList(enumType);

                    promise.then(function (result) {
                        return service.getEnumLocalization(enumType, enumValue);
                    }, function (reason) {
                        return result;
                    });
                }
                else {
                    for (var i = 0; i < service.enumList[enumType].length; i++) {
                        if (service.enumList[enumType][i].value === enumValue) {
                            result = service.enumList[enumType][i].localizationValue;
                            break;
                        }
                    }
                    return result;
                }
            };
            //
            service.getEnumList = function (enumType) {
                var deferred = $q.defer();

                if (angular.isArray(service.enumList[enumType])) {
                    deferred.resolve(service.enumList[enumType]);
                    return deferred.promise;
                }

                enumService.getEnumList(enumType)
                    .success(function (data) {
                        service.enumList[enumType] = data;
                        deferred.resolve(data);
                    }).error(function (message) {
                        service.enumList[enumType] = null;
                        deferred.reject(message);
                    });

                return deferred.promise;
            };
            /******************************  End  *************************************************************************/
            /******************************  Initialize  ******************************************************************/
            service.initialize();
            /******************************  End  *************************************************************************/
        }
    ]);
})();
