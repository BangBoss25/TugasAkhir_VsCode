// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Js Add & Edit Item

function validateFileExt(id) {
    var inputFile = document.getElementById('file' + id);
    var pathFile = inputFile.value;
    var ekstensiOk = /(\.jpg|\.jpeg|\.png)$/i;
    if (!ekstensiOk.exec(pathFile)) {
        if (pathFile == "") {
            inputFile.value = '';
            if (id == "1") {
                document.getElementById('preview1').innerHTML = '';
            }
            else if (id == "2") {
                document.getElementById('preview2').innerHTML = '';
            }
            else if (id == "3") {
                document.getElementById('preview3').innerHTML = '';
            }
            else if (id == "4") {
                document.getElementById('preview4').innerHTML = '';
            }
        }
        else {
            alert('Silakan upload file yang dengan ekstensi .jpeg/.jpg/.png');
            inputFile.value = '';
            if (id == "1") {
                document.getElementById('preview1').innerHTML = '';
            }
            else if (id == "2") {
                document.getElementById('preview2').innerHTML = '';
            }
            else if (id == "3") {
                document.getElementById('preview3').innerHTML = '';
            }
            else if (id == "4") {
                document.getElementById('preview4').innerHTML = '';
            }
        }
        return false;
    }
    else {
        if (inputFile.files && inputFile.files[0]) {
            if (id == "1") {
                var reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementById('preview1').innerHTML = '<img src="' + e.target.result + '" style="height:130px; margin-bottom: 5px;"/>';
                };
                reader.readAsDataURL(inputFile.files[0]);
            }
            else if (id == "2") {
                var reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementById('preview2').innerHTML = '<img src="' + e.target.result + '" style="height:130px; margin-bottom: 5px;"/>';
                };
                reader.readAsDataURL(inputFile.files[0]);
            }
            else if (id == "3") {
                reader.onload = function (e) {
                    document.getElementById('preview3').innerHTML = '<img src="' + e.target.result + '" style="height:130px; margin-bottom: 5px;"/>';
                };
                reader.readAsDataURL(inputFile.files[0]);
            }
            else if (id == "4") {
                reader.onload = function (e) {
                    document.getElementById('preview4').innerHTML = '<img src="' + e.target.result + '" style="height:130px; margin-bottom: 5px;"/>';
                };
                reader.readAsDataURL(inputFile.files[0]);
            }
        }
    }
}

function validateInputNumber(event, obj) {
    var keyCode = event.keyCode ? event.keyCode : event.which;

    if (keyCode == 8 || keyCode == 46 || keyCode == 37 || keyCode == 39 || (keyCode > 95 && keyCode < 106))
        return true;

    if (keyCode < 48 || keyCode > 57 || event.shiftKey || event.altKey) {
        event.preventDefault();
        return false;
    }
}