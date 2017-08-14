(function () {
    angular.module('app').controller('app.views.roles.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.role',
        function ($scope, $uibModalInstance, roleService) {
            var vm = this;

            vm.role = {};
            vm.permissions = [];

            function getPermissions() {
                roleService.getAllPermissions()
                    .then(function (result) {
                        vm.permissions = result.data.items;
                    });
            }

            vm.save = function () {
                var assignedPermissions = [];
                for (var i = 0; i < vm.permissions.length; i++) {
                    var permission = vm.permissions[i];
                    if (!permission.isAssigned) {
                        continue;
                    }

                    assignedPermissions.push(permission.name);
                }
                
                vm.role.permissions = assignedPermissions;
                roleService.create(vm.role)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getPermissions();
        }
    ]);
})();