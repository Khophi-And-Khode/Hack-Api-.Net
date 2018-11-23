/*/////////////////////////////////
 * @Author: Samuel Wendolin Ketechie
 * @Date: November 22,2018 18:00 
 /*////////////////////////////////

var apiLink = apiUrl + "/api/main/upload/";



var imgObj = document.getElementById("fileToUpload");
var img = imgObj.textContent;
function UpLoader() {
    $.ajax({
        url: apiLink + img,
        method: "POST",
        dataType: "json",
        data: img,
        contentType: "application/json",
        success: function (data) {
            return data;
        }
    });
}
document.getElementById("btnUpload").addEventListener("click", UpLoader);

$(function () {

});
