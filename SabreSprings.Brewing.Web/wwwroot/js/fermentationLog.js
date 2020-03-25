$(document).ready(function () {
    GetAllLogs();
    window.setInterval(function () {
        GetAllLogs()
    }, 5000);
});



function GetAllLogs() {
    $.ajax({
        url: "/api/FermentabuoyLog/GetAllLogs",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            DisplayLogs(data);
        },
        error: function (data) {

        }
    });
}

function DisplayLogs(data) {
    $.each(data, function (i, obj) {
        $('#tap' + obj.tapNumber + 'BeerDisplayName').html(obj.beerDisplayName + ' Batch #' + obj.batchNumber);
        $('#tap' + obj.tapNumber + 'Style').html(obj.style);
        $('#tap' + obj.tapNumber + 'ABV').html(parseFloat(obj.abv).toFixed(1) + "%");
        $('#tap' + obj.tapNumber + 'PintsRemaining').html(obj.pintsRemaining.toFixed(2) + " pints remaining");
        $('#tap' + obj.tapNumber + 'TastingNotes').html(obj.tastingNotes);
        $('#tap' + obj.tapNumber + 'Logo').attr("src", obj.logo);
        $('#tap' + obj.tapNumber + 'Details').attr("href", '/Batch/Details/' + obj.batchId);
    }); 
}
