$(document).ready(function () {
    GetTaps();
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
    var a = 5;
    $.each(data, function (i, obj) {
        $('#tap' + obj.tapNumber + 'BeerDisplayName').html(obj.beerDisplayName);
        $('#tap' + obj.tapNumber + 'Style').html(obj.style);
        $('#tap' + obj.tapNumber + 'ABV').html(parseFloat(obj.abv).toFixed(1) + "%");
        $('#tap' + obj.tapNumber + 'PintsRemaining').html(obj.pintsRemaining + " pints remaining");
        $('#tap' + obj.tapNumber + 'TastingNotes').html(obj.tastingNotes);
        $('#tap' + obj.tapNumber + 'Logo').attr("src", obj.logo);
    });
    
  
}