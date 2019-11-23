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
       var  htmlString =  "<h3>" + obj.beerDisplayName + "</h3>Batch #" +  obj.batchNumber + "<br/>" +
           "ABV: " + obj.abv + "<br/>Pints Remaining: " + obj.pintsRemaining;
        $("#tapDisplay"+ obj.tapNumber.toString()).html(htmlString);
    });
    
  
}