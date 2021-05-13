$(document).ready(function () {
    LoadData();
});

function AddCourse() {

    var course = {
        code: $('#codeC').val(),
        name: $('#nameC').val(),
        credits: parseInt($('#creditsC').val()),
        semester: $('#semesterC').val(),
        year: parseInt($('#yearC').val()),
    };

    $.ajax({
        url: "/Course/Add",
        data: JSON.stringify(course),
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
        url: "/Course/GetEF", //DUDA CUAL GET ES 
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
                html += '<td>' + item.credits + '</td>';
                html += '<td>' + item.semester + '</td>';
                html += '<td>' + item.year + '</td>';
                html += '<td><a href="#" onclick="return Get(' + item.id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
            });
            $('.tbody').html(html);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

function RemoveCourse(id) { //DISTINTA AL PROFE

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Course/Remove",
        data: JSON.stringify(id),
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
            alert("ELIMINADO");
            LoadDataCourse();
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

//UPDATE Y DELETE

function GetStudentsById(id) { //llame al controlador home

    var id;
    document.getElementById("getById").style.visibility = 'visible'; //NUEVA SECCIÓN DE EDITAR EN HTML

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Course/GetCourse",
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


//UPDATE
function Update() {

    var student = {
        id: parseInt($('#id_update').val()),  // TODO: Load state from previously suspended application
        code: $('#code').val(),
        name: $('#name').val(),
        email: $('#email').val(),
        password: $('#password').val()
    };

    $.ajax({
        url: "/Student/Update",
        data: JSON.stringify(student),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Cancel();
            LoadData();
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}


function AddProfessor() {

    var professor = {
        code: $('#codeC').val(),
        name: $('#nameC').val(),
        credits: parseInt($('#creditsC').val()),
        semester: $('#semesterC').val(),
        year: parseInt($('#yearC').val()),
    };

    $.ajax({
        url: "/Professor/Add",
        data: JSON.stringify(professor),
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
                html += '<td>' + item.credits + '</td>';
                html += '<td>' + item.semester + '</td>';
                html += '<td>' + item.year + '</td>';
                html += '<td><a href="#" onclick="return Get(' + item.id + ')">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')">Delete</a></td>';
            });
            $('.tbody').html(html);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

function RemoveCourse(id) { //DISTINTA AL PROFE

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Professor/Remove",
        data: JSON.stringify(id),
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
            alert("ELIMINADO");
            LoadDataCourse();
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}