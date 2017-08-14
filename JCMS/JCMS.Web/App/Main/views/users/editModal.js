(function () {
    angular.module('app').controller('app.views.users.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.user', 'id',
        function ($scope, $uibModalInstance, userService, id) {
            var vm = this;

            vm.user = {
                isActive: true
            };

            vm.roles = [];

            var setAssignedRoles = function (user, roles) {
                for (var i = 0; i < roles.length; i++) {
                    var role = roles[i];
                    role.isAssigned = $.inArray(role.name, user.roles) >= 0;
                }
            }

            var init = function () {
                userService.getRoles()
                    .then(function (result) {
                        vm.roles = result.data.items;

                        userService.get({ id: id })
                            .then(function (result) {
                                vm.user = result.data;
                                setAssignedRoles(vm.user, vm.roles);
                            });
                    });
            }

            vm.save = function () {
                var assingnedRoles = [];

                for (var i = 0; i < vm.roles.length; i++) {
                    var role = vm.roles[i];
                    if (!role.isAssigned) {
                        continue;
                    }

                    assingnedRoles.push(role.name);
                }

                vm.user.roleNames = assingnedRoles;
                userService.update(vm.user)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            init();
        }
    ]);
})();