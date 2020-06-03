(function () {
    var controllerId = 'app.views.directives.smartTable.smartTableController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        '$modal',
        'services.common.filterExpresionFactory',
        'services.common.sorterExpresionFactory',
        'services.common.enumService',
        function ($scope, $modal, filterExpresionFactory, sorterExpresionFactory, enumService) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.data = [];
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.callServer = function (tableState) {
                if (ctrl.isLoading)
                    return;

                abp.ui.setBusy();
                ctrl.isLoading = true;

                var pagination = tableState.pagination;

                var start = pagination.start || 0;     // This is NOT the page number, but the index of item in the list that you want to use to display the table.
                var number = pagination.number || 10;  // Number of entries showed per page.

                //start, number, tableState
                ctrl.entityPagedRequestDto = ctrl.getEntityPagedRequestDto(tableState);

                $scope.entityService.getEntityPaged(ctrl.entityPagedRequestDto)
                    .success(function (data) {
                        ctrl.data = data.items;
                        //set the number of pages so the pagination can update
                        tableState.pagination.numberOfPages = data.totalCount > 0 ? Math.ceil(data.totalCount / data.maxResultCount) : 0;
                        ctrl.isLoading = false;
                        abp.ui.clearBusy();
                    }).error(function (message) {
                        abp.notify.error(App.localize('NissanSystem.ErrorMessage.FailedRequest'));
                        abp.ui.clearBusy();
                    });
            };
            //
            ctrl.getEntityPagedRequestDto = function (tableState) {
                var entityPagedRequestDto = new Object();

                entityPagedRequestDto.maxResultCount = 10;
                entityPagedRequestDto.skipCount = 0;
                entityPagedRequestDto.filterList = ctrl.getFilterList(tableState.search);
                entityPagedRequestDto.sorter = ctrl.getSorter(tableState.sort);

                return entityPagedRequestDto;
            };
            //
            ctrl.getFilterList = function (search) {
                var filterList = [];

                if (search === {} || !angular.isObject(search.predicateObject))
                    return filterList;

                for (var pathEntity in search.predicateObject) {
                    var propertyValue = null;
                    var propertyType = null;
                    var expresionFilter = null;

                    if (!search.predicateObject.hasOwnProperty(pathEntity))
                        continue

                    propertyValue = search.predicateObject[pathEntity];

                    for (var j = 0; j < $scope.propertyInfoList.length; j++) {
                        if ($scope.propertyInfoList[j].pathEntity === pathEntity) {
                            pathEntity = $scope.propertyInfoList[j].pathEntity;
                            propertyType = $scope.propertyInfoList[j].propertyType;
                            break;
                        }

                    }

                    switch (propertyType) {
                        case enumService.expresionFilter.propertyType.text: {
                            expresionFilter = new filterExpresionFactory(enumService.expresionFilter.unionFilter.or, propertyType, enumService.expresionFilter.optionFilter.contains, pathEntity, propertyValue);
                            break;
                        }
                        case enumService.expresionFilter.propertyType.int: {
                            expresionFilter = new filterExpresionFactory(enumService.expresionFilter.unionFilter.or, propertyType, enumService.expresionFilter.optionFilter.equals, pathEntity, propertyValue);
                            break;
                        }
                        default: {
                            expresionFilter = new filterExpresionFactory(enumService.expresionFilter.unionFilter.or, propertyType, enumService.expresionFilter.optionFilter.equals, propertyName, propertyValue);
                            break;
                        }
                    }

                    filterList.push(expresionFilter);
                }

                return filterList;
            };
            //
            ctrl.getSorter = function (sort) {
                var expresionSorter = null;

                if (angular.equals({}, sort))
                    return expresionSorter;

                var columnName = sort.predicate;
                var ascendig = sort.reverse;

                var expresionSorter = new sorterExpresionFactory(columnName, ascendig);

                return expresionSorter;
            };
            //
            ctrl.selectItem = function (entity) {
                if (angular.isFunction($scope.selectCallBack)) {
                    $scope.selectCallBack()(entity);
                    return;
                }
            };
            /******************************  End  *************************************************************************/
        }
    ]);

    /*Scopre Attributes: 
    ngModel => entity
    serverCall => function pagination
    selectCallBack => function to call on entity selected
    propertyInfoList => List of properties, setted by factory PropertyInfo
    */
    app.directive('smartTableDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entityService: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                selectCallBack: '&',
                propertyInfoList: '='
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/views/directives/smartTable/smartTableDirective.cshtml',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();