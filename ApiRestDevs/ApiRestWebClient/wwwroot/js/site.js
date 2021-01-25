// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getToken() {   
    var link = "http://localhost:5000/api/login";

    var request = $.ajax({
        url: link,
        type: 'POST',
        dataType: 'json',
        contentType: "application/json",
        crossDomain: true,
        processData: false,
        data: "{ \"username\": \"santi\", \"password\": \"santi\" }"
    });

    request.done(function (data) {
        console.log(data);
    });

    request.fail(function (jqXHR, textStatus, errorThrown) {
        console.log(jqXHR.responseText || textStatus);
    });
}