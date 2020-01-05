

function GetBatchDetails(id) {
    $.ajax({
        url: "/api/Batch/GetBatchDetails",
        data: 'id='+ id,
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
    $('#header').html(data.beer);
    var html = '<div id="attributes">';
    var color = '';
    if (data.status.includes("On Tap")) {
        color = "green";
    }
    else if (data.status === "Fermenting") {
        color = "red";
    }
    else if (data.status === "Conditioning") {
        color = "#D2D545";
    }
    else if (data.status === "Archived") {
        color = "#1369B1";
    }
    else if (data.status === "Planned") {
        color = "#B11313";
    }
    $('#header').html(data.beer);
    $('#header').css('color', color);
    html += '<ul>';
    html += '<li><b style="color:'+color+'">Batch Number:</b>&nbsp;' + data.batchNumber + '</li>';
    html += '<li><b style="color:'+color+'">Style:</b>&nbsp;' + data.style + '</li>';
    html += '<li><b style="color:'+color+'">Brewers:</b>&nbsp;' + data.brewers + '</li>';
    html += '<li><b style="color:'+color+'">Recipe:</b>&nbsp;' + data.recipe + '</li>';
    html += '<li><b style="color:'+color+'">Yeast:</b>&nbsp;' + data.yeast + '</li>';
    html += '<li><b style="color:'+color+'">Pre-boil Gravity:</b>&nbsp;' + data.preBoilGravity + '</li>';
    html += '<li><b style="color:'+color+'">Original Gravity:</b>&nbsp;' + data.originalGravity + '</li>';
    html += '<li><b style="color:'+color+'">Final Gravity:</b>&nbsp;' + data.finalGravity + '</li>';
    html += '<li><b style="color:'+color+'">ABV:</b>&nbsp;' + parseFloat(data.abv).toFixed(1) + "%" + '</li>';
    html += '<li><b style="color:'+color+'">Date Brewed:</b>&nbsp;' + (new Date(data.dateBrewed)).toLocaleDateString('en-US') + '</li>';
    //Original DateTime(not DateTime2) returns default of 12/31/1969 when null
    if (new Date(data.datePackaged).toLocaleDateString('en-US') !== '12/31/1969') {
        html += '<li><b style="color:'+color+'">Date Packaged:</b>&nbsp;' + (new Date(data.datePackaged)).toLocaleDateString('en-US') + '</li>';
    } 
    //Original DateTime(not DateTime2) returns default of 12/31/1969 when null
    if (new Date(data.dateTapped).toLocaleDateString('en-US') !== '12/31/1969') {
        html += '<li><b style="color:'+color+'">Date Tapped:</b>&nbsp;' + (new Date(data.dateTapped)).toLocaleDateString('en-US') + '</li>';
    } 
    html += '</ul></div>';
    if (data.brewingNotes != null) {
        html += '<div><h3>Brewing Notes</h3>';
        html += '<p style="white-space: pre-line">' + data.brewingNotes + '</p>';
    }
    if (data.tastingNotes != null) {
        html += '<div><h3>Tasting Notes</h3>';
        html += '<p style="white-space: pre-line">' + data.tastingNotes + '</p>';
        html += '</div>';  
    }

    $('#details').html(html);
}