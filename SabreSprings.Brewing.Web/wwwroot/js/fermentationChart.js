$(document).ready(function () {
    GetAllLogs();
    GetBuoyNames();
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

function GetBuoyNames() {
    $.ajax({
        url: "/api/FermentabuoyLog/GetBuoyNames",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (buoyNames) {
            BuoySelectionBox(buoyNames);
        },
        error: function (buoyNames) {

        }
    });
}

function DisplayLogsChart(data, buoyNames) {
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
            height: 750,
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

    /*$("#names").dxSelectBox({
        dataSource: buoyNames,
        valueExpr: "name",
        displayExpre: "name",
        height: function () {
            return window.innerHeight / "50px";
        },
        width: function () {
            return window.innerWidth / "100px";
        },
        //onValueChanged: function (e) {
            //chart.option("commonSeriesSettings.type", e.value);
       // }
        padding: 20,
        margin: {
            top: 20,
            bottom: 20,
            right: 10,
        },
        fontSize: 18,
        fontWeight: 500,
    });*/
}

function BuoySelectionBox(buoyNames) {
    var buoyBox = $("#names").dxSelectBox({
        dataSource: buoyNames,
        valueExpr: "name",
        displayExpr: "name",
        value: "FermentABuoy001",
        height: function () {
            return window.innerHeight / "50px";
        },
        width: function () {
            return window.innerWidth / "100px";
        },
        //onValueChanged: function (e) {
        //chart.option("commonSeriesSettings.type", e.value);
        // }
        padding: 20,
        margin: {
            top: 20,
            bottom: 20,
            right: 10,
        },
        fontSize: 18,
        fontWeight: 500,
    });
}
