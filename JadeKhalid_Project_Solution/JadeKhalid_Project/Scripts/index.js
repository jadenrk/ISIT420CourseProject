
var uri = 'api/Data';

var indicatorsArray = [""];

$(document).ready(function () {
    GetCountryDropdown();
    GetIndicatorsDropdowns();
    //GetStoreDropdown();
});

// populating the drpdown for q1
function GetCountryDropdown() {
    $.getJSON('api/Q1')
        .done(function (data) {0
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                // THIS LINE NEEDS EDITING
                $('<option id=' + item.dtoCountryID + '>' + item.dtoCountryName + '</option>').appendTo($('#countryDropdown'));
            });
        });
}

// populating the dropdown for q2 and q3
function GetIndicatorsDropdowns() {
    $.getJSON('api/Data')
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                // THIS LINE NEEDS EDITING
                $('<option id=a' + item + '>' + item + '</option>').appendTo($('#indicatorDropdownOne'));
                $('<option id=b' + item + '>' + item + '</option>').appendTo($('#indicatorDropdownTwo'));
            });
        });
}

// return data relevant to country selected in query 1
function getCountryData() {
    $("#thisCountryData").empty();
    var id = $('#countryDropdown option:selected').attr('id');
    $.getJSON('api/Q1/' + id)
        .done(function (data) {
            //$('#thisCountryData').text($('#thisCountryData option:selected').text() );
            $('<h2>' + $('#countryDropdown option:selected').text() + '</h2><p>HDI Rank: ' + data.myHdiRank + ' | HDI Score: ' + data.myHdiScore + '</br>' +
                'SFI Rank: ' + data.mySfiRank + ' | SFI Score: ' + data.mySfiScore + '</br >' + '</p>' + 
                '<h3>Indicators</h3> <ul> <li>Security Apparatus: ' + data.mySfiSec +
                '</li> <li>Factionalized Elites: ' + data.mySfiFaction +
                '</li> <li>Group Grievance: ' + data.mySfiGgriev +
                '</li> <li>Economy: ' + data.mySfiEcon +
                '</li> <li>Economic Inequality: ' + data.mySfiEcIneq +
                '</li> <li>Human Flight and Brain Drain: ' + data.mySfiHFlight +
                '</li> <li>State Legitimacy: ' + data.mySfiSLegit +
                '</li> <li>Public Services: ' + data.mySfiPub +
                '</li> <li>Human Rights: ' + data.mySfiRights +
                '</li> <li>Demographic Pressures: ' + data.mySfiDem +
                '</li> <li>Refugees and IDPs: ' + data.mySfiRef +
                '</li> <li>External Intervention: ' + data.mySfiExtInt +
                '</li></ul>').appendTo($('#thisCountryData'));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#thisCountryData').text('Error: ' + err);
        });
}

// return countries with good scores relevant to selected indicator
function getStrongScoreCountries() {
    $("#strongScoreCountries").empty();
    var id = $('#indicatorDropdownOne option:selected').attr('id'); // THIS LINE NEEDS EDITING
    $.getJSON('api/Q2/' + id)
        .done(function (data) {
            $('#strongScoreCountries').text($('#indicatorDropdownOne option:selected').text() + ' sold $' + data + ' for the year. '); //THIS LINE NEEDS EDITING
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#strongScoreCountries').text('Error: ' + err);
        });
}

// return countries with bad scores relevant to selected indicator
function getWeakScoreCountries() {
    $("#weakScoreCountries").empty();
    var id = $('#indicatorDropdownTwo option:selected').text(); // THIS LINE NEEDS EDITING
    $.getJSON('api/Q3/' + id)
        .done(function (data) {
            $.each(data, function (key, item) {
                // Add a list item for the product.
                // THIS LINE NEEDS EDITING
                $('<span>' + item + '</span>').appendTo($('#weakScoreCountries'));
            });
            //$('#weakScoreCountries').text($(data)); //THIS LINE NEEDS EDITING
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#weakScoreCountries').text('Error: ' + err);
        });
}