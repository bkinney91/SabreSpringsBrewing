$(document).ready(function () {
    GetRecipeHeaders();
});




function GetRecipeHeaders() {
    $.ajax({
        url: "/api/Recipe/GetRecipeHeaders",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GenerateTable(data);
        },
        error: function (data) {

        }
    });
}



function GenerateTable(data) {
    $(function () {
        $("#gridContainer").dxDataGrid({
            dataSource: data,
            keyExpr: "recipe",
            selection: {
                mode: "single"
            },
            hoverStateEnabled: true,
            showBorders: true,
            columnsAutoWidth: true,
            filterRow: {
                visible: true,
                applyFilter: "auto"
            },
            searchPanel: {
                visible: true,
                placeholder: "Search..."
            },
            headerFilter: {
                visible: true
            },
            columns: [{
                dataField: "name",
                caption: "Name"
            },
            {
                dataField: "style",
                caption: "Style"
            }],
            onSelectionChanged: function (selectedItems) {
                var data = selectedItems.selectedRowsData[0];
                console.log(data);
                window.location.replace("/Recipe/Details?id=" + data.recipe);
            }
        });
    });
}