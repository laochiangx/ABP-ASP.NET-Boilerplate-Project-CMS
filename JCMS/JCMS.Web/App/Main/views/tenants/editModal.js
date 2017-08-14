(function () {
    angular.module('app').controller('app.views.tenants.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.tenant', 'id',
        function ($scope, $uibModalInstance, tenantService, id) {
            var vm = this;

            vm.tenant = {};

            function init() {
                tenantService.get({
                    id: id
                }).then(function (result) {
                    vm.tenant = result.data;
                });
            }

            init();

            vm.save = function () {
                abp.ui.setBusy();
                tenantService.update(vm.tenant)
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