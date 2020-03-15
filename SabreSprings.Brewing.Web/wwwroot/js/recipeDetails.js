$(document).ready(function () {
    GetRecipeDetails($('#recipeId').val());
});


function GetRecipeDetails(id) {
    $.ajax({
        url: "/api/Recipe/GetRecipe",
        data: 'id=' + id,
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

function DisplayDetails(data){
    $('#beerName').html(data.name);
    $('#style').html("<i>" + data.style + "</i>");
}