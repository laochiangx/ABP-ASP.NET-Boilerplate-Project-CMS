//权限授权模态框操作js函数




var $modal = $("#authorizeModal");
var zTree;

/*******弹出表单*********/
function ShowModal_Authorize(actionUrl, param, title) {
    //表单初始化
    $(".modal-title", $modal).html(title);
    $("#modal-content", $modal).attr("action", actionUrl);
    $("#roleId", $modal).val(param.id);
    var treeSetting = {
        view: {
            selectedMulti: false
        },
        check: {
            enable: true
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        edit: {
            enable: false
        },
        callback: {
            // onCheck: onCheck
        }
    };
    $.ajax({
        type: "GET",
        url: actionUrl,
        data: param,
        beforeSend: function () {
            //
        },
        success: function (zNodes) {
            zTree = $.fn.zTree.init($("#treePermission", $modal), treeSetting, zNodes);
            $modal.modal('show');
        },
        error: function () {
            //
        },
        complete: function () {
            //
        }
    });
}


//“权限授权”模态框中保存

function SaveModal_Authorize(actionUrl) {
    var nodes = zTree.getCheckedNodes(true);
    var l = nodes.length;
    if (l <= 0) {
        toastr.warning('请至少选择一项权限！');
        return;
    } else {
        var leaves = "";
        for (var i = 0; i < l; i++) {
            if (!nodes[i].isParent) {
                leaves += nodes[i].id + ",";
            }
        }
        var roleId = $("#roleId", $modal).val();
        var param = { roleid: roleId, ids: leaves };
        $.ajax(
        {
            type: 'POST',
            url: actionUrl,
            data: param,
            success: function (result) {
                if (result.ResultType === 0) {
                    toastr.success(result.Message);
                    $modal.modal('hide');
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
}
