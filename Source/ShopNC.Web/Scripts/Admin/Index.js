$(function () {
    initLeftMenuEvent();
    showTime();

    //tab右击菜单
    tabClose();
    tabCloseEvent();
})


function initLeftMenuEvent() {
    $(".menuItem").click(function () {

        var title = $(this).text();
        var url = $(this).attr("href");
        var icon = $(this).attr("icon");

        //判断是否存在选项卡
        if ($('#tabs').tabs('exists', title)) {
            $('#tabs').tabs('select', title);
        }

        else {
            addTab(title, icon, url);
        }

        //让菜单导向不会导向到单独的页面如<a href="UserInfo/Index" class="menuItem">用户管理</a>
        return false;
    });
}

function addTab(title, icon, url) {

    $('#tabs').tabs('add', {
        title: title,
        content: createFrame(url),
        closable: true,
        icon: icon,
        tools: [{
            iconCls: 'icon-mini-refresh',
            handler: function () {
                // alert('refresh');
                $('#mm-tabupdate').click();
            }
        }]
    });
    tabClose();

}

function showTime() {
    setInterval(function () {
        var timeNow = (new Date()).pattern("yyyy-MM-dd HH:mm:ss EEE");
        $("#date").html(timeNow);
    }, 1000);
}

function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', {
            left: e.pageX,
            top: e.pageY
        });

        var subtitle = $(this).children(".tabs-closable").text();

        $('#mm').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//绑定右键菜单事件
function tabCloseEvent() {
    //刷新
    $('#mm-tabupdate').click(function () {
        var currTab = $('#tabs').tabs('getSelected');
        var url = $(currTab.panel('options').content).attr('src');
        $('#tabs').tabs('update', {
            tab: currTab,
            options: {
                content: createFrame(url)
            }
        })
    })
    //关闭当前
    $('#mm-tabclose').click(function () {
        var t = $('#mm').data("currtab");
        if (t !== "首页") {
            $('#tabs').tabs('close', t);//currtab_title
        }
    })
    //全部关闭
    $('#mm-tabcloseall').click(function () {
        $('.tabs-inner span').each(function (i, n) {
            var t = $(n).text();
            if (t !== "首页")
                $('#tabs').tabs('close', t);
        });
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {
        $('#mm-tabcloseright').click();
        $('#mm-tabcloseleft').click();
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            //alert('后边没有啦~~');
            return false;
        }
        nextall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            if (t !== "首页")
                $('#tabs').tabs('close', t);
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            //alert('到头了，前边没有啦~~');
            return false;
        }
        prevall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            if (t !== "首页")
                $('#tabs').tabs('close', t);
        });
        return false;
    });

    //退出
    $("#mm-exit").click(function () {
        $('#mm').menu('hide');
    })
}

function createFrame(url) {
    var s = '<iframe scrolling="no" frameborder="0"  src="' + url + '" style="width:100%;height:99%;"></iframe>';
    return s;
}