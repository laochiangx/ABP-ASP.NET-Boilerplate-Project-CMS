(function () {
    angular.module('app').controller('app.views.tenants.index', [
        '$scope', '$uibModal', 'abp.services.app.tenant',
        function ($scope, $uibModal, tenantService) {
            var vm = this;

            vm.tenants = [];

            function getTenants() {
                tenantService.getAll({}).then(function (result) {
                    vm.tenants = result.data.items;
                });
            }

            vm.openTenantCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/tenants/createModal.cshtml',
                    controller: 'app.views.tenants.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getTenants();
                });
            };

            vm.openTenantEditModal = function (tenant) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/tenants/editModal.cshtml',
                    controller: 'app.views.tenants.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return tenant.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getTenants();
                });
            }

            vm.delete = function (tenant) {
                abp.message.confirm(
                    "Delete tenant '" + tenant.name + "'?",
                    function (result) {
                        if (result) {
                            tenantService.delete({ id: tenant.id })
                                .then(function () {
                                    abp.notify.info("Deleted tenant: " + tenant.name);
                                    getTenants();
                                });
                        }
                    });
            }

            vm.refresh = function() {
                getTenants();
            };

            getTenants();
        }
    ]);
})();