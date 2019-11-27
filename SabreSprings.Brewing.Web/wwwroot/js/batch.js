function BuildTable() {
    $("#batchTable").dxDataGrid({
        dataSource: customers,
        columns: ["CompanyName", "City", "State", "Phone", "Fax"],
        showBorders: true
    });
}