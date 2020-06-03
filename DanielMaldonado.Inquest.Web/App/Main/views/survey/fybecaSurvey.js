(function () {
    var controllerId = 'app.views.survey.fybecaSurvey';
    var app = angular.module('app');

    app.controller(controllerId, [
        '$scope',
        'abp.services.app.surveyService',
        'abp.services.app.surveyedService',
        'abp.services.app.branchOfficeService',
        function ($scope, surveyService, surveyedService, branchOfficeService) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.entity = null;
            ctrl.app = App;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.initialize = function () {
                ctrl.entity = new Object();
                ctrl.entity.personSurveyed = new Object();

                var entityPagedRequestDto = new Object();

                surveyService.getEntityPaged(entityPagedRequestDto)
                    .then(function (response) {
                        if (angular.isArray(response.data.items)) {
                            ctrl.entity.survey = response.data.items[0];
                        }
                    }, function (error) {
                        console.log(response);
                    });

                branchOfficeService.getEntityPaged(entityPagedRequestDto)
                    .then(function (response) {
                        if (angular.isArray(response.data.items)) {
                            ctrl.branchOfficeList = response.data.items;
                        }
                    }, function (error) {
                        console.log(response);
                    });
            };
            //
            ctrl.sorterFunc = function (questionOption) {
                if (!isNaN(questionOption.value))
                    return parseInt(questionOption.value);
                else
                    return false;
            };
            //
            ctrl.save = function () {
                ctrl.entity.answerList = ctrl.getAnswerList();

                surveyedService.insertEntity(ctrl.entity)
                    .then(function (response) {
                        if (angular.isArray(response.data)) {
                        }
                    }, function (error) {
                        console.log(response);
                    });
            };
            //
            ctrl.getAnswerList = function () {
                var list = [];
                for (var i = 0; i < ctrl.entity.survey.questionList.length; i++) {
                    var answer = new Object();
                    answer.question = ctrl.entity.survey.questionList[i];
                    answer.questionType = ctrl.entity.survey.questionList[i].questionType;
                    answer.questionOption = ctrl.entity.survey.questionList[i].selected;
                    answer.freeAnswer = "";

                    list.push(answer);
                }
                return list;
            };
            /******************************  End  *************************************************************************/
            /******************************  Initialize  ******************************************************************/
            //
            ctrl.initialize();
            /******************************  End  *************************************************************************/
        }
    ]);
})();