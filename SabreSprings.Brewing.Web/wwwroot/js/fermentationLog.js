$(document).ready(function () {
    GetAllLogs();
});



function GetAllLogs() {
    $.ajax({
        url: "/api/FermentabuoyLog/GetAll",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            DisplayLogsTable(data);
        },
        error: function (data) {

        }
    });
}

function DisplayLogsTable(data) {
    $('#fermentationLogTable').dxDataGrid({
        dataSource: data,
        columns: [
            { dataField: "name", caption: "Name" },
            { dataField: "temperature", caption: "Temperature" },
            { dataField: "gravity", caption: "Gravity" },
            { dataField: "angle", caption: "Angle" },
            { dataField: "id", caption: "DeviceID" },
            { dataField: "battery", caption: "Battery" },
            { dataField: "rssi", caption: "RSSI" },
            { dataField: "created", caption: "Created", dataType: "datetime", displayFormat: "short" },
        ],
        showBorders: true,
        columnAutoWidth: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        paging: {
            pageSize: 25
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [25, 50, 100],
            showInfo: true
        },
        filterRow: {
            visible: true,
            applyFilter: "auto"
        },
        searchPanel: {
            visible: true,
            width: 240,
            placeholder: "Search..."
        },
        headerFilter: {
            visible: true
        },
        }); 
}
