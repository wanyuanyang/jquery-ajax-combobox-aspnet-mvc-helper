$(function () {
    $('#tabs').tabs(
                { cache: true },
                {
                    ajaxOptions: {
                        cache: false,
                        error: function (xhr, status, index, anchor) {
                            $(anchor.hash).html("Couldn't load this tab.");
                        },
                        data: {},
                        success: function (data, textStatus) { }
                    },
                    add: function (event, ui) {
                        //select the new tab
                        $('#tabs').tabs('select', '#' + ui.panel.id);
                    }
                });
});

function addTab(title, uri) {
    var newTab = $("#tabs").tabs("add", uri, title);
}

function closeTab() {
    var index = getSelectedTabIndex();
    $("#tabs").tabs("remove", index)
}

function getSelectedTabIndex() {
    return $("#tabs").tabs('option', 'selected');
}

function RefershList() {
    $('#frmUserList').submit();
}