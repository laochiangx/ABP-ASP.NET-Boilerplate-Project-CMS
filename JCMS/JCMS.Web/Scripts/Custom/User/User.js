

/*******“设置角色”和“设置用户组”弹出表单*********/
function ShowModal_Setting(actionUrl, param, title,$settingModal) {
    //表单初始化
    $(".modal-title", $settingModal).html(title);
    $("#modal-content", $settingModal).attr("action", actionUrl);

    $.ajax({
        type: "GET",
        url: actionUrl,
        data: param,
        success: function (result) {
            $("#modal-content", $settingModal).html(result);
            $settingModal.modal('show');
            //RegisterForm();//通过Ajax加载返回的页面原有MVC属性验证将失效，需要重新注册验证脚本。
        }
    });
}


//“设置角色”&&“设置用户组”模态框中保存

function SaveModal_Setting($settingModal) {
    var actionUrl = $("#modal-content", $settingModal).attr("action");
    var $form = $("#modal-content", $settingModal);
    $.ajax({
        type: "POST",
        url: actionUrl,
        data: $form.serialize(),
        success: function (result) {
            if (result.ResultType === 0) {
                toastr.success(result.Message);
                $settingModal.modal('hide');
            }
            else {
                toastr.error(result.Message);
            }
        },
        error: function () {
            toastr.error('网络错误，请重新提交！');
        }
    });
}


