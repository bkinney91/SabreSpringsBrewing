$(document).ready(function () {
    GetBatches();
});

function GetBatches() {
    $.ajax({
        url: "/api/Batch/GetAllBatches",
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
        columns: ["batchNumber", "batchName", "beer"],
        showBorders: true
    });
}