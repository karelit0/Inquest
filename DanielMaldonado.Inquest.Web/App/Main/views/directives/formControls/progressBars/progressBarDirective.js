(function () {
    var controllerId = 'app.views.directives.formControls.progressBarController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            ctrl.progressValue = 0;
            ctrl.types = null;
            ctrl.type = null;
            ctrl.placeHolder = null;
            ctrl.index = 0;

            ctrl.image = null;

            ctrl.animationElement = null;
            ctrl.contex = null;
            ctrl.width = null;
            ctrl.height = null;
            ctrl.fps = 5;
            ctrl.currentFps = ctrl.fps;
            ctrl.currentAnimationImagePosition = 0;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            ctrl.iniatialize = function () {
                ctrl.types = ['danger', 'warning', 'success'];
                ctrl.changeProgressValueByIndex(1);
                ctrl.beginAnimation();
                $scope.directive = ctrl;
            };
            //
            ctrl.changeProgressValueByIndex = function (index) {
                ctrl.index = index;
                var value = (index / $scope.stepList.length) * 100;
                var title = $scope.stepList[index - 1].header;

                ctrl.changeProgressValue(value, title);
            };
            //
            ctrl.changeProgressValue = function (value, title) {
                ctrl.progressValue = value;
                ctrl.placeHolder = title;

                if (value < 35) {
                    ctrl.type = ctrl.types[0];
                    return;
                }

                if (value >= 35 && value < 80) {
                    ctrl.type = ctrl.types[1];
                    return;
                }
                ctrl.type = ctrl.types[2];
            };
            //
            ctrl.beginAnimation = function () {
                if (ctrl.contex === null) {
                    ctrl.animationElement = $('#animationCanvas');
                    ctrl.contex = document.getElementById('animationCanvas').getContext('2d');
                    ctrl.contex.globalCompositeOperation = 'destination-over';
                    ctrl.width = ctrl.contex.canvas.width;
                    ctrl.height = ctrl.contex.canvas.height;
                }

                var imagePath = 'content/images/image.progress.bar.png';
                ctrl.loadImage(imagePath)
                    .done(function (image) {
                        ctrl.image = image;
                        window.requestAnimationFrame(ctrl.drawScene);
                    })
                    .fail(function (image) {
                    });
            };
            //
            ctrl.beginTransition = function () {
                var progressWidth = $('.progress-striped').width();
                var progressWidthUnit = progressWidth / $scope.stepList.length;
                var tranlateX = (progressWidth * ctrl.progressValue / 100) - progressWidthUnit;

                ctrl.animationElement.css('position', 'initial');
                ctrl.animationElement.css('transition', 'all 2s ease-in-out');
                ctrl.animationElement.css('-webkit-transition', 'all 2s ease-in-out');
                ctrl.animationElement.css('-moz-transition', 'all 2s ease-in-out');
                ctrl.animationElement.css('-o-transition', 'all 2s ease-in-out');

                ctrl.animationElement.css('-webkit-transform', 'translate(' + tranlateX + 'px,0)');
                ctrl.animationElement.css('-o-transform', 'translate(' + tranlateX + 'px,0)');
                ctrl.animationElement.css('-moz-transform', 'translate(' + tranlateX + 'px,0)');
            };
            /******************************  End  *************************************************************************/
            /******************************  Canvas  **********************************************************************/
            //
            ctrl.drawScene = function () {
                if (ctrl.currentFps < ctrl.fps) {
                    ctrl.currentFps++;
                    window.requestAnimationFrame(ctrl.drawScene);
                    return;
                }

                ctrl.currentFps = 0;

                ctrl.contex.clearRect(0, 0, ctrl.width, ctrl.height); // clear canvas
                ctrl.drawAnimation();
                ctrl.beginTransition();

                ctrl.contex.save();

                window.requestAnimationFrame(ctrl.drawScene);
            };
            //
            ctrl.drawAnimation = function () {
                if (ctrl.currentAnimationImagePosition >= 4)
                    ctrl.currentAnimationImagePosition = 0;

                var spriteNumber = 4;

                var imageSpriteWidth = (ctrl.image.width / spriteNumber);
                var imageSpritePosition = imageSpriteWidth * ctrl.currentAnimationImagePosition;

                ctrl.contex.drawImage(ctrl.image, imageSpritePosition, 0, imageSpriteWidth, ctrl.image.height, 0, 0, ctrl.width, ctrl.height);

                ctrl.currentAnimationImagePosition++;
            };
            /******************************  End  *************************************************************************/
            /******************************  Loaders  *********************************************************************/
            //
            ctrl.loadImage = function (url) {
                // Define a "worker" function that should eventually resolve or reject the deferred object.
                var loadImage = function (deferred) {
                    var image = new Image();

                    // Set up event handlers to know when the image has loaded
                    // or fails to load due to an error or abort.
                    image.onload = loaded;
                    image.onerror = errored; // URL returns 404, etc
                    image.onabort = errored; // IE may call this if user clicks "Stop"

                    // Setting the src property begins loading the image.
                    image.src = url;

                    function loaded() {
                        unbindEvents();
                        // Calling resolve means the image loaded sucessfully and is ready to use.
                        deferred.resolve(image);
                    }
                    function errored() {
                        unbindEvents();
                        // Calling reject means we failed to load the image (e.g. 404, server offline, etc).
                        deferred.reject(image);
                    }
                    function unbindEvents() {
                        // Ensures the event callbacks only get called once.
                        image.onload = null;
                        image.onerror = null;
                        image.onabort = null;
                    }
                };

                // Create the deferred object that will contain the loaded image.
                // We don't want callers to have access to the resolve() and reject() methods, 
                // so convert to "read-only" by calling `promise()`.
                return jQuery.Deferred(loadImage).promise();
            };
            /******************************  End  *************************************************************************/
            /******************************  Iniatialize  *****************************************************************/
            ctrl.iniatialize();
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('progressBarDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                directive: '=',
                stepList: '='
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: 'Views/directives/formControls/progressBars/progressBarDirective.cshtml',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();