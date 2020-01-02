

function GetBatchDetails() {
    $.ajax({
        url: "/api/Batch/GetBatchDetails",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            DisplayDetails(data);
        },
        error: function (data) {

        }
    });
}

function DisplayDetails(data) {
    var html = '';
    

}