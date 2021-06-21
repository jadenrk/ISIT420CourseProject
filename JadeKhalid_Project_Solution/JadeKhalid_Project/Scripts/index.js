
var uri = 'api/Data';

$(document).ready(function () {
    GetCountryDropdown();
    //GetStoreDropdown();
});

// populating the drpdown for q1
function GetCountryDropdown() {
    $.getJSON('api/Q1')
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                // THIS LINE NEEDS EDITING
                $('<option id=' + item.dtoCountryID + '>' + item.dtoCountryName + '</option>').appendTo($('#countryDropdown'));
            });
        });
}

// populating the dropdown for q2 and 3?
function GetIndicatorsDropdownOne () {
    $.getJSON('api/Q2')
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                // THIS LINE NEEDS EDITING
                //$('<option id=' + item.dtoStoreID + '>' + item.dtoCity + '</option>').appendTo($('#indicatorDropdownOne'));
            });
        });
}

function GetIndicatorsDropdownTwo() {
    $.getJSON('api/Q3')
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                // THIS LINE NEEDS EDITING
                //$('<option id=' + item.dtoStoreID + '>' + item.dtoCity + '</option>').appendTo($('#indicatorDropdownTwo'));
            });
        });
}

// return data relevant to country selected in query 1
function getCountryData() {
    $("#thisCountryData").empty(); 
    $.getJSON('api/Q1/')
        .done(function (data) {
            console.log(data);
            $.each(data, function (key, item) {
                // Add a list item for the product.
                //THIS LINE NEEDS EDITING
                $('<li>Store ' + item.StoreID + ':   ' + item.Count + ' CDs over $13.</li>').appendTo($('#notes'));
            });
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#thisCountryData').text('Error: ' + err);
        });
}

// return countries with good scores relevant to selected indicator
function getStrongScoreCountries() {
    var id = $('#indicatorDropdownOne option:selected').attr('id'); // THIS LINE NEEDS EDITING
    $.getJSON('api/Q2/' + id)
        .done(function (data) {
            console.log(data);
            $('#strongScoreCountries').text($('#indicatorDropdownOne option:selected').text() + ' sold $' + data + ' for the year. '); //THIS LINE NEEDS EDITING
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#strongScoreCountries').text('Error: ' + err);
        });
}

// return countries with low scores relevant to selected indicator
function getWeakScoreCountries() {
    var id = $('#indicatorDropdownTwo option:selected').attr('id'); // THIS LINE NEEDS EDITING
    $.getJSON('api/Q3/' + id)
        .done(function (data) {
            console.log(data);
            $('#weakScoreCountries').text($('#indicatorDropdownTwo option:selected').text() + ' sold $' + data + ' for the year. '); //THIS LINE NEEDS EDITING
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#weakScoreCountries').text('Error: ' + err);
        });
}