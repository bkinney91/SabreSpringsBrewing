$(document).ready(function () {
    GetBatches();
});

function GetBatches() {
    $.ajax({
        url: "/api/Batch/GetBatchTable",
        type: 'GET',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            DisplayCards(data);
        },
        error: function (data) {

        }
    });
}

function openBatchDetails(id) {
    var win = window.open('/Batch/Details/' + id, '_blank');
    win.focus();
}

function DisplayCards(data) {
    var html ='';
    $.each(data, function (i, obj) {
        var color;
        if (obj.statusText.includes("On Tap")) {
            color = "green";
        }
        else if (obj.statusText === "Fermenting") {
            color = "red";
        }
        else if (obj.statusText === "Conditioning") {
            color = "#D2D545";
        }
        else if (obj.statusText === "Archived") {
            color = "#1369B1";
        }
        else if (obj.statusText === "Planned") {
            color = "#B11313";
        }
        var thisCard = '<div class="card" style="border-color:' + color + ';border-top-width:5px;border-width:5px" onclick="openBatchDetails('+ obj.batchId + ')">';
        thisCard += '<div class="card-header" style="border-color:' + color + ';border-bottom-width: 10px">';
        thisCard += obj.statusText;
        thisCard += '</div><div class="card-body"><h5 class="card-title">';
        thisCard += obj.beerName + ' Batch #' + obj.batchNumber;
        thisCard += '</h5><h6 class="card-subtitle mb-2 text-muted">';
        thisCard += obj.style;
        thisCard += '<p class="card-text">';
        thisCard += 'Date Brewed: ' + (new Date(obj.dateBrewed)).toLocaleDateString('en-US') + '<br/>';
        //Original DateTime(not DateTime2) returns default of 12/31/1969 when null
        if (new Date(obj.datePackaged).toLocaleDateString('en-US') !== '12/31/1969')
        {   
            thisCard += 'DatePackaged: ' + (new Date(obj.datePackaged)).toLocaleDateString('en-US') + '<br/>';
        }        
        thisCard += '</p>';
        thisCard += '<a href="#" class="card-link" onclick="openBatchDetails(' + obj.batchId + ')">Batch Details</a>';
        thisCard += '</div></div>';
        thisCard += '</br>';
        html += thisCard;
    });
    $('#batchTable').html(html);

}
