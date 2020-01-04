$(document).ready(function () {
    GetTaps();
    window.setInterval(function () {
        GetTaps()
    }, 5000);
});



function GetTaps() {
    $.ajax({
        url: "/api/Tap/GetOnTap",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            DisplayTaps(data);
        },
        error: function (data) {

        }
    });
}

function DisplayTaps(data) {
    $.each(data, function (i, obj) {
        $('#tap' + obj.tapNumber + 'BeerDisplayName').html(obj.beerDisplayName + ' Batch #' + obj.batchNumber);
        $('#tap' + obj.tapNumber + 'Style').html(obj.style);
        $('#tap' + obj.tapNumber + 'ABV').html(parseFloat(obj.abv).toFixed(1) + "%");
        $('#tap' + obj.tapNumber + 'PintsRemaining').html(obj.pintsRemaining.toFixed(2) + " pints remaining");
        $('#tap' + obj.tapNumber + 'TastingNotes').html(obj.tastingNotes);
        $('#tap' + obj.tapNumber + 'Logo').attr("src", obj.logo);
        $('#tap' + obj.tapNumber + 'Details').attr("onclick", 'openBatchDetails(' + obj.batchId + ')');
    }); 
}

function openBatchDetails(id) {
    var win = window.open('/Batch/Details/' + id, '_blank');
    win.focus();
}