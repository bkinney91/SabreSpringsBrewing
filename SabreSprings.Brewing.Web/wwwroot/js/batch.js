$(document).ready(function () {
    GetBatches();
});

function GetBatches() {
    $.ajax({
        url: "/api/Batch/GetBatchTable",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            BuildTable(data);
        },
        error: function (data) {

        }
    });
}



function BuildTable(data) {
    $("#batchTable").dxDataGrid({
        dataSource: data,
        editing: {
            mode: "popup",
            allowUpdating: true,
            popup: {
                title: "Employee Info",
                showTitle: true,
                width: 700,
                height: 525,
                position: {
                    my: "top",
                    at: "top",
                    of: window
                }
            },
            form: {
                items: [{
                    itemType: "group",
                    colCount: 2,
                    colSpan: 2,
                    items: ["Beer", "BatchNumber", "BatchName", "Status", "SubStatus", "HireDate", {
                        dataField: "Notes",
                        editorType: "dxTextArea",
                        colSpan: 2,
                        editorOptions: {
                            height: 100
                        }
                    }]
                }, {
                    itemType: "group",
                    colCount: 2,
                    colSpan: 2,
                    caption: "Home Address",
                    items: ["StateID", "Address"]
                }]
            }
        },
        columns: ["statusText","beerName", "style", "batchNumber"],
        showBorders: true
    });
}