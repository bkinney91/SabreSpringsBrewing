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
            DisplayLogsChart(data);
        },
        error: function (data) {

        }
    });
}

function DisplayLogsChart(data) {
    var fermentationChart = $("#fermentationChart").dxChart({        
        dataSource: data,
        commonSeriesSettings: {
            argumentField: "created",            
            type: "line",
            aggregation: {
                enabled: true
            }
        },
        margin: {
            bottom: 20
        },
        size: {
            height: 800,
            width: 1000
        },       
        argumentAxis: {
            valueMarginsEnabled: false,            
            argumentType: "datetime",            
            aggregationInterval:"day",
            tickInterval: { days: 2 },           
            grid: {
                visible: true
            }
        },       
        series: [            
            { valueField: "temperature", name: "Temperature" },
            { valueField: "gravity", name: "Gravity" },
            { valueField: "angle", name: "Angle" },
            { valueField: "battery", name: "Battery" },
            { valueField: "rssi", name: "RSSI" },
        ],
        legend: {
            verticalAlignment: "bottom",
            horizontalAlignment: "center",
            itemTextPosition: "bottom"
        },
        title: {
            text: "Fermentation Chart",
            subtitle: {
                text: "(Timelapse Trend)"
            }
        },
        "export": {
            enabled: true
        },
        tooltip: {
            enabled: true
        },
        loadingIndicator: {
            enabled: true
        }
    }).dxChart("instance");    
}
