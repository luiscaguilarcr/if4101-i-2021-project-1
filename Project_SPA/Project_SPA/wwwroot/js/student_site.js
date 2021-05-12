// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    
});

function Add() { //PISTAS DE AUDITORÍA

    var student = {
        code: $('#code').val(),
        name: $('#full name').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        creationUser: "Luis",
        creationDate: "2021-05=01 18:09:20.357",
        updateUser: "Luis",
        updateDate: "2021-05=01 18:09:20.357"
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

function LoadData() {
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
                html += '<td><a href="#" onclick="return Get(' + item.id + ')">Editar</a> | <a href="#" onclick="Remove(' + item.id + ')">Eliminar</a></td>';
            });
            $('.tbody').html(html);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

//UPDATE Y DELETE

function Remove(id) { //DISTINTA AL PROFE

    var id;

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Student/Delete",
        data: JSON.stringify(id),
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
            alert("ELIMINADO");
            LoadData();
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

//DEBEMOS CREA UNA NUEVA SECCIÓN PARA UPDATE

/*
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
            document.getElementById("id_update").value = result.id;
            document.getElementById("name_update").value = result.name;
            document.getElementById("email_update").value = result.email;
            document.getElementById("password_update").value = result.password;
            document.getElementById("major_update").value = result.major.id;
            document.getElementById("nationality_update").value = result.nationality.id;
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}
 */

//METODO UPDATE

/*
 function Update() { //llame al controlador home

    var student = { //var tipo de variable genetica (no tiene tipo especifico) OBJETO ESTUDIANTE
        id: parseInt($('#id_update').val()),
        name: $('#name_update').val(), //Obtenemos el valor que la persona digita en el formulario
        email: $('#email_update').val(),
        id_major: parseInt($('#major_update').val()),
        password: $('#password_update').val(),
        id_nationality: parseInt($('#nationality_update').val())
    };

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Home/Update",
        data: JSON.stringify(student),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
            alert("Updated User");
            Cancel();
            LoadData();
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}


 */