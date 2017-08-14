(function () {
    var controllerId = 'app.views.layout.rightSidebar';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$timeout', '$state', 'appSession', 'abp.services.app.configuration',
        function ($rootScope, $timeout, $state, appSession, configurationService) {
            var vm = this;

            vm.selectedThemeCssClass = "red";
            vm.themes = [
                createUiThemeInfo("Red", "red"),
                createUiThemeInfo("Pink", "pink"),
                createUiThemeInfo("Purple", "purple"),
                createUiThemeInfo("Deep Purple", "deep-purple"),
                createUiThemeInfo("Indigo", "indigo"),
                createUiThemeInfo("Blue", "blue"),
                createUiThemeInfo("Light Blue", "light-blue"),
                createUiThemeInfo("Cyan", "cyan"),
                createUiThemeInfo("Teal", "teal"),
                createUiThemeInfo("Green", "green"),
                createUiThemeInfo("Light Green", "light-green"),
                createUiThemeInfo("Lime", "lime"),
                createUiThemeInfo("Yellow", "yellow"),
                createUiThemeInfo("Amber", "amber"),
                createUiThemeInfo("Orange", "orange"),
                createUiThemeInfo("Deep Orange", "deep-orange"),
                createUiThemeInfo("Brown", "brown"),
                createUiThemeInfo("Grey", "grey"),
                createUiThemeInfo("Blue Grey", "blue-grey"),
                createUiThemeInfo("Black", "black")
            ];

            function createUiThemeInfo(name, cssClass) {
                return {
                    name: name,
                    cssClass: cssClass
                };
            }

            function init() {
                vm.selectedThemeCssClass = abp.setting.get('App.UiTheme');
                $('body').addClass('theme-' + vm.selectedThemeCssClass);

                //Fix for uib-tab does not have id propert, but BSB admin requires it
                $timeout(function () {
                    $("div.demo-settings").closest('div').attr("id", 'settings');
                }, 0);
            }

            vm.setTheme = function (theme) {

                configurationService.changeUiTheme({ theme: theme.cssClass }).then(function () {
                    var $body = $('body');
                    $('.right-sidebar .demo-choose-skin li').removeClass('active');
                    $body.removeClass('theme-' + vm.selectedThemeCssClass);
                    $('.right-sidebar .demo-choose-skin li div.' + theme.cssClass).closest('li').addClass('active');
                    $body.addClass('theme-' + theme.cssClass);

                    vm.selectedThemeCssClass = theme.cssClass;
                });
            }

            init();
        }
    ]);
})();