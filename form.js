// DOC READY


var saveInfo = function () {
    var input = {
        'bookTitle' :  $("#txtTitle")[0].value,
        'authorFirstName': $("#txtFirstName")[0].value,
        'authorLastName': $("#txtLastName")[0].value,
        'bookEdition': $("#txtEdition")[0].value,
        'publisherName': $("#txtPublisherName")[0].value,
        'publishedDate': $("#txtDatePublished")[0].value
    };

    $.ajax({
        url: "https://localhost:7110/api/BookInfo/AddBookInfo",
        type: "POST",
        data: JSON.stringify(input),
        contentType: "application/json",
        dataType: "text/plain",
        success: function (response) {
            //console.log(response);
        }
        ,
        error: function (xhr, status, error) {
            console.log(xhr.responseText);
        }
    });
    console.log(input);
};

var delInfo = function () {
    var input = {
        'bookTitle': $("#delTitle")[0].value,
        'authorFirstName': $("#delFirstName")[0].value,
        'authorLastName': $("#delLastName")[0].value,
    };

    $.ajax({
        url: "https://localhost:7110/api/BookInfo/DeleteBookInfo",
        type: "DELETE",
        data: JSON.stringify(input),
        contentType: "application/json",
        dataType: "text/plain",
        success: function (response) {
            //console.log(response);
        }
        ,
        error: function (xhr, status, error) {
            console.log(xhr.responseText);
        }
    });
    console.log(input);
};

$(document).ready(function () {
    $("#btnSave").click(saveInfo);
    $("#btnDelete").click(delInfo);
});