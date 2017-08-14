(function () {
    angular.module('app').controller('app.views.tenants.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.tenant',
        function ($scope, $uibModalInstance, tenantService) {
            var vm = this;

            vm.tenant = {
                tenancyName: '',
                name: '',
                adminEmailAddress: '',
                connectionString: ''
            };

            vm.save = function () {
                abp.ui.setBusy();
                tenantService.create(vm.tenant)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();