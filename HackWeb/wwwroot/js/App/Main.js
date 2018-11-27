/*/////////////////////////////////
 * @Author: Samuel Wendolin Ketechie
 * @Date: November 22,2018 18:00 
 /*////////////////////////////////

var apiLink = apiUrl;

var imgObj = document.getElementById("fileToUpload").innerHTML;
var UpLoader = function () {
    $.ajax({
        url: apiLink + "cy.jpg",
        method: "POST",
        contentType: "multipart/form-data",
        success: function (data) {
            alert(data);
        }
    });
};

$(function () {
    document.getElementById("btnUpload").addEventListener("click", UpLoader);
});
