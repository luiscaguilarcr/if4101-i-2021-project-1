// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () { //DOM cargado, siempre va 
    ocultarAdmin();
    
});

function validateAdmin() {

    if ((document.getElementById("userName").value == "admin") && (document.getElementById("userPassword").value == "admin2021")) {
     
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
    document.getElementById('#register').style.display = 'none';
    document.getElementById('register').style.display = 'none';
    document.getElementById('sign_out_admin').style.display = 'none';
    document.getElementById('#team').style.display = 'none';
    document.getElementById('#courses').style.display = 'none';
    document.getElementById('#testimonial').style.display = 'none';
    document.getElementById('#contact').style.display = 'none';
    document.getElementById('team').style.display = 'none';
    document.getElementById('register').style.display = 'none'; 
    document.getElementById('edit').style.display = 'none';

}

function aparecerAdmin() {
    document.getElementById('register').style.display = 'block';
    document.getElementById('sign_out_admin').style.display = 'block';
    document.getElementById('#about').style.display = 'none';
    document.getElementById('about').style.display = 'none';
    document.getElementById('#team').style.display = 'block';
    document.getElementById('#feature').style.display = 'none';
    document.getElementById('register').style.display = 'block';
    document.getElementById('#register').style.display = 'block';
}

function sign_out_admin() {
    document.getElementById('#about').style.display = 'block';
    document.getElementById('#register').style.display = 'none';
    document.getElementById('#team').style.display = 'none';
    document.getElementById('#feature').style.display = 'block';
    document.getElementById('obj1').style.display = 'block';
    document.getElementById('sign_in').style.display = 'block';
    document.getElementById('about').style.display = 'block';
    document.getElementById('register').style.display = 'none';
    document.getElementById('sign_out_admin').style.display = 'none';
}

function registerOnClick() {
    document.getElementById('register').style.display = 'block';
    document.getElementById('team').style.display = 'none';
}

function studentsOnClick() {
    LoadDataStudent();
    document.getElementById('team').style.display = 'block';
    document.getElementById('students').style.display = 'block';
    document.getElementById('teachers').style.display = 'none';
    document.getElementById('register').style.display = 'none';
    document.getElementById('courses').style.display = 'none';
}

function teachersOnClick() {
    document.getElementById('team').style.display = 'block';
    document.getElementById('teachers').style.display = 'block';
    document.getElementById('register').style.display = 'none';
    document.getElementById('courses').style.display = 'none';
    document.getElementById('students').style.display = 'none';
}

function coursesOnClick() {
    document.getElementById('team').style.display = 'block';
    document.getElementById('courses').style.display = 'block';
    document.getElementById('teachers').style.display = 'none';
    document.getElementById('register').style.display = 'none';
    document.getElementById('students').style.display = 'none';
}
function AddStudent() { //PISTAS DE AUDITORÍA

    var student = {
        code: $('#codeS').val(),
        name: $('#nameS').val(),
        email: $('#emailS').val(),
        password: $('#passwordS').val()
    };

    $.ajax({
        url: "/Student/Add",
        data: JSON.stringify(student),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}


function LoadDataStudent() {
    $.ajax({
        url: "/Student/GetEF", //DUDA CUAL GET ES 
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.code + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td>' + item.password + '</td>';
                html += '<td><a href="#students" onclick="return GetStudentsById(' + item.id + ')">Editar</a> | <a href="#students" onclick="Remove(' + item.id + ')">Eliminar</a></td>';
            });
            $('.tbodyStudent').html(html);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

function Remove(id) { //DISTINTA AL PROFE

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Student/Remove",
        data: JSON.stringify(id),
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
            alert("ELIMINADO");
            LoadDataStudent();
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}
function GetStudentsById(id) { //llame al controlador home

    var id;
    document.getElementById("getById").style.visibility = 'visible'; //NUEVA SECCIÓN DE EDITAR EN HTML

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Home/GetStudentsById",
        data: JSON.stringify(id),
        type: "PUT", //Put trae y pone
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
            document.getElementById("edit").style.display = 'block';
            document.getElementById("editStud").style.display = 'block';
            document.getElementById("editProf").style.display = 'none';
            document.getElementById("editCourse").style.display = 'none';

        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

function closeedit() {
    document.getElementById("edit").style.display = 'none';
}

function Update() {

    var student = {
        id: parseInt($('#id_update').val()),  // TODO: Load state from previously suspended application
        code: $('#code').val(),
        name: $('#name').val(),
        email: $('#email').val(),
        password: $('#password').val()
    };

    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(student),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            
            LoadData();
            closeedit()
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

function LoadDataProfessor() {
    $.ajax({
        url: "/Professor/GetEF", //DUDA CUAL GET ES 
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.code + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td>' + item.password + '</td>';
                html += '<td><a href="#" onclick="return Get(' + item.id + ')">Editar</a> | <a href="#" onclick="Remove(' + item.id + ')">Eliminar</a></td>';
            });
            $('.tbodyStudent').html(html);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

