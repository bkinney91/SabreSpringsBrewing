$(document).ready(function () {
    GetTaps();
});

function GetTaps() {
    $.ajax({
        url: "/api/TapController/GetOnTap",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        sucess: function (data) {
            DisplayTaps(data);
        },
        error: function (data) {

        }
    });
}

function DisplayTaps(data) {
   
    $.each(data, function (i, obj) {
        var htmlString = "<table>";
        //use obj.id and obj.name here, for example:
        htmlstring += "<tr><td>" + obj.BeerDisplayName + "</td><td>" + obj.BatchNumber + "</td></tr>";
        htmlstring += "</table>";
        $("#tapDisplay"+ obj.TapNumber.toString()).html(htmlString);
    });
    
  
}