// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () { //DOM cargado, siempre va 
    ocultarAdmin();
});


function validateAdmin() {

    if ((document.getElementById("userName").value == "admin") && (document.getElementById("userPassword").value == "admin2021")) {

        alert("Exito");       
        ocultarEstud();
        aparecerAdmin();
    } else {
        alert("error");
    }

}
function ocultarEstud() {
    document.getElementById('obj1').style.display = 'none';
    document.getElementById('sign_in').style.display = 'none';
}

function ocultarAdmin() {
    document.getElementById('obj2').style.display = 'none';
    document.getElementById('obj3').style.display = 'none';
    document.getElementById('sign_out_admin').style.display = 'none';
}
function aparecerAdmin() {
    
    document.getElementById('obj2').style.display = 'block';
    document.getElementById('obj3').style.display = 'block';
    document.getElementById('sign_out_admin').style.display = 'block';
}

function sign_out_admin() {
    document.getElementById('obj1').style.display = 'block';
    document.getElementById('sign_in').style.display = 'block';

    document.getElementById('obj2').style.display = 'none';
    document.getElementById('obj3').style.display = 'none';
    document.getElementById('sign_out_admin').style.display = 'none';
}