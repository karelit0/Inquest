var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('Inquest');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

    App.labelColumnForm = 'col-lg-3';
    App.inputColumnForm = 'col-lg-9';

    App.pattern = new Object();
    App.pattern.cedula = /^\d{10}$/;
    App.pattern.word = /^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s\d]*$/;
    App.pattern.email = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    App.pattern.cellphone = /^09\d{8}$/;
    App.pattern.phone = /^\d{7}\d*$/;
    App.pattern.age = /^\d{1}[\d{1}]?$/;
    App.pattern.gender = /^[MmFf]$/;

    App.newGuid = function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                .toString(16)
                .substring(1);
        }
        return s4() + s4() + s4() + s4() + s4() + s4() + s4() + s4();
    }

})(App);