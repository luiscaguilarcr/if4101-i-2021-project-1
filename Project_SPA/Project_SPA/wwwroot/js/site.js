// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () { //DOM cargado, siempre va 
    ocultarAdmin();
});

function validateAdmin() {

    var user = {
        code = document.getElementById("userName").value;
        password = document.getElementById("userPassword").value;
    }

    if (loginAdmin(user)) {
        ocultarEstud();
        aparecerAdmin();
        Clean_lognin();
    } else if (loginProfessor(user)) {
        ocultarEstud();
        
    } else if (loginStudent(user)) {
        student_singin();
    }

}

function loginAdmin(user){

    $.ajax({
        url: "/User/LogInAdmin",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            return true;
        },
        error: function (errorMessage) {
            return false;
        }
    });
}

function loginProfessor(user) {

    $.ajax({
        url: "/User/LogInProfessor",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            return true;
        },
        error: function (errorMessage) {
            return false;
        }
    });
}

function loginStudent(user) {

    $.ajax({
        url: "/User/LogInStudent",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            return true;
        },
        error: function (errorMessage) {
            return false;
        }
    });
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
    document.getElementById('#studentProfile').style.display = 'none';
    document.getElementById('studentProfile').style.display = 'none';
    document.getElementById('sign_out_student').style.display = 'none';
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
    document.getElementById('team').style.display = 'none';
    document.getElementById('edit').style.display = 'none';
    document.getElementById('sign_out_admin').style.display = 'none';
    
}

function sign_out_student() {
    document.getElementById('#studentProfile').style.display = 'none';
    document.getElementById('studentProfile').style.display = 'none';
    document.getElementById('#about').style.display = 'block';
    document.getElementById('#feature').style.display = 'block';
    document.getElementById('obj1').style.display = 'block';
    document.getElementById('sign_in').style.display = 'block';
    document.getElementById('about').style.display = 'block';
    document.getElementById('sign_out_student').style.display = 'none';
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
    LoadDataProfessor();
    document.getElementById('team').style.display = 'block';
    document.getElementById('teachers').style.display = 'block';
    document.getElementById('register').style.display = 'none';
    document.getElementById('courses').style.display = 'none';
    document.getElementById('students').style.display = 'none';
}

function coursesOnClick() {
    LoadDataCourse();
    document.getElementById('team').style.display = 'block';
    document.getElementById('courses').style.display = 'block';
    document.getElementById('teachers').style.display = 'none';
    document.getElementById('register').style.display = 'none';
    document.getElementById('students').style.display = 'none';
}

function studentProfileOnClick() {
    document.getElementById('#studentProfile').style.display = 'block';
    document.getElementById('studentProfile').style.display = 'block';

}


function student_singin() {
    document.getElementById('#about').style.display = 'none';
    document.getElementById('about').style.display = 'none';
    document.getElementById('sign_in').style.display = 'none';
    document.getElementById('sign_out_student').style.display = 'block';
    document.getElementById('#feature').style.display = 'none';
    document.getElementById('#studentProfile').style.display = 'block';
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
            Clean_student();
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

//------------------------------------------------------------------------------------------------
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
            alert("insertado con exito");
            Clean_curses();
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

function LoadDataCourse() {
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
                html += '<td><a href="#" onclick="return Get(' + item.id + ')">Edit</a> | <a href="#courses" onclick="RemoveCourse(' + item.id + ')">Delete</a></td>';
            });
            $('.tbodyCourse').html(html);
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
//-----------------------------------------------------------------------------------------

function AddProfessor() {

    var professor = {
        code: $('#codeP').val(),
        name: $('#nameP').val(),
        email: $('#emailP').val(),
        password: $('#passwordP').val(),
        AcademicDegreeId: parseInt($('#AcadGradeP').val()),
    };

    $.ajax({
        url: "/Professor/Add",
        data: JSON.stringify(professor),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("insertado con exito");
            Clean_professor();
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
                html += '<td>' + item.email + '</td>';
                html += '<td><a href="#" onclick="return Get(' + item.id + ')">Edit</a> | <a href="#teachers" onclick="RemoveProfessor(' + item.id + ')">Delete</a></td>';
            });
            $('.tbodyProfessor').html(html);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}
function RemoveProfessor(id) { //DISTINTA AL PROFE

    $.ajax({ //Simbolo de dolar todo lo de jquery
        url: "/Professor/Remove",
        data: JSON.stringify(id),
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //aca recibo el resultafo del backend (datos,objetos,mensajes)
            alert("ELIMINADO");
            LoadDataProfessor();
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

function Clean_lognin() {
    document.getElementById("userName").value = "";
    document.getElementById("userPassword").value = "";
}

function Clean_student() {
    document.getElementById("codeS").value = "";
    document.getElementById("nameS").value = "";
    document.getElementById("emailS").value = "";
    document.getElementById("passwordS").value = "";
    document.getElementById("repeatpasswordS").value = "";
}

function Clean_professor() {
    document.getElementById("nameP").value = "";
    document.getElementById("codeP").value = "";
    document.getElementById("emailP").value = "";
    document.getElementById("AcadGradeP").value = "Grado Académico";
    document.getElementById("passwordP").value = "";
    document.getElementById("repeatpasswordP").value = "";

}

function Clean_curses() {
    document.getElementById("nameC").value = "";
    document.getElementById("codeC").value = "";
    document.getElementById("creditsC").value = "";
    document.getElementById("semesterC").value = "Semestre";
    document.getElementById("yearC").value = "Año de carrera";

}

