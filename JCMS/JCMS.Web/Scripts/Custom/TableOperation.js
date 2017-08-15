var m_pagerow = 0;
//初始化Table
function InitTable(tb, actionUrl, dbQueryParams, tbColumns) {
    $(tb).bootstrapTable({
        url: actionUrl,         //请求后台的URL（*）
        method: 'get',                      //请求方式（*）
        toolbar: '#toolbar',                //工具按钮用哪个容器
        striped: true,                      //是否显示行间隔色
        cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
        pagination: true,                   //是否显示分页（*）
        sortable: false,                     //是否启用排序
        sortOrder: "asc",                   //排序方式
        queryParams: dbQueryParams,//传递参数（*）
        sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1,                       //初始化加载第一页，默认第一页
        pageSize: 10,                       //每页的记录行数（*）
        pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
        search: false,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
        strictSearch: true,
        showColumns: true,                  //是否显示所有的列
        showRefresh: true,                  //是否显示刷新按钮
        //minimumCountColumns: 2,             //最少允许的列数
        clickToSelect: true,                //是否启用点击选中行
        height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
        uniqueId: "Id",                     //每一行的唯一标识，一般为主键列
        showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
        cardView: false,                    //是否显示详细视图
        detailView: false,                   //是否显示父子表
        columns: tbColumns,
        onPageChange: function (number, size) {
            m_pagerow = (number - 1) * size;
        }
    });
};

//表格行多选删除
function MultDelete(table, actionUrl) {
    var arrselections = $(table).bootstrapTable('getSelections');
    if (arrselections.length <= 0) {
        toastr.warning('请选择有效数据');
        return;
    }
    WinMsg.confirm({ message: "确认要删除选择的数据吗？" }).on(function (e) {
        if (!e) {
            return;
        }
        $.ajax({
            type: "post",
            url: actionUrl,
            data: { "arrselections": JSON.stringify(arrselections) },
            success: function (result) {
                if (result.ResultType == 0) {
                    toastr.success(result.Message);
                    $(table).bootstrapTable('refresh');
                }
                else {
                    toastr.error(result.Message);
                }
            },
            error: function () {
                toastr.error('网络错误，请重新提交！');
            }
        });
    });
}

//重置密码
function MultReset(table, actionUrl) {
    var arrselections = $(table).bootstrapTable('getSelections');
    if (arrselections.length <= 0) {
        toastr.warning('请选择有效数据');
        return;
    }
    WinMsg.confirm({ message: "确定要将已选择用户的密码重置为初始密码“123456”吗？" }).on(function (e) {
        if (!e) {
            return;
        }
        $.ajax({
            type: "post",
            url: actionUrl,
            data: { "arrselections": JSON.stringify(arrselections) },
            success: function (result) {
                if (result.ResultType == 0) {
                    toastr.success(result.Message);
                    //$(table).bootstrapTable('refresh');
                }
                else {
                    toastr.error(result.Message);
                }
            },
            error: function () {
                toastr.error('网络错误，请重新提交！');
            }
        });
    });
}
