(function () {
    var controllerId = 'app.views.layout.topbar';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;
            vm.languages = [];
            vm.currentLanguage = {};

            function init() {
                vm.languages = abp.localization.languages;
                vm.currentLanguage = abp.localization.currentLanguage;
            }

            vm.changeLanguage = function (languageName) {
                location.href = abp.appPath + 'AbpLocalization/ChangeCulture?cultureName=' + languageName + '&returnUrl=' + window.location.pathname + window.location.hash;
            }

            init();

        }
    ]);
})();