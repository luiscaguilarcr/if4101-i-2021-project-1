// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () { //DOM cargado, siempre va 
    HideAdmin();
    HideProfessor();
    HideStudent();
});


//////////////////////////////////////////////////// HIDE ////////////////////////////////////////////////////
function HideAdmin() {
    document.getElementById('sign_out_admin').style.display = 'none';

    document.getElementById('#edit_admin_profile').style.display = 'none';
    document.getElementById('edit_admin_profile').style.display = 'none';

    document.getElementById('#newNot').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';

    document.getElementById('#edit_professor_student_course').style.display = 'none';
    document.getElementById('edit_student').style.display = 'none';
    document.getElementById('edit_professor').style.display = 'none';
    document.getElementById('edit_course').style.display = 'none';

    document.getElementById('#tables').style.display = 'none';
    document.getElementById('students').style.display = 'none';
    document.getElementById('teachers').style.display = 'none';
    document.getElementById('courses').style.display = 'none';

    document.getElementById('#register_professor_course').style.display = 'none';
    document.getElementById('register_professor_course').style.display = 'none';

    document.getElementById('#student_register_requests').style.display = 'none';
    //document.getElementById('student_register_requests').style.display = 'none';
}

function HideProfessor() {
    document.getElementById('sign_out_professor').style.display = 'none';

    document.getElementById('#edit_professor_profile').style.display = 'none';
    document.getElementById('edit_professor_profile').style.display = 'none';

}

function HideStudent() {
    document.getElementById('sign_out_student').style.display = 'none';

    document.getElementById('#edit_student_profile').style.display = 'none';
    document.getElementById('edit_student_profile').style.display = 'none';

}

function HideStudentSignIn() {
    document.getElementById('#edit_student').style.display = 'block';
    document.getElementById('sign_out_student').style.display = 'block';
    document.getElementById('about').style.display = 'none';
    document.getElementById('sign_in').style.display = 'none';
}
//////////////////////////////////////////////////// SHOW ////////////////////////////////////////////////////
function ShowAdmin() {
    document.getElementById('sign_out_admin').style.display = 'block';

    document.getElementById('#edit_admin_profile').style.display = 'block';
    document.getElementById('edit_admin_profile').style.display = 'block';

    document.getElementById('#newNot').style.display = 'block';
    document.getElementById('newNot').style.display = 'block';

    document.getElementById('#edit_professor_student_course').style.display = 'block';
    document.getElementById('edit_student').style.display = 'block';
    document.getElementById('edit_professor').style.display = 'block';
    document.getElementById('edit_course').style.display = 'block';

    document.getElementById('#tables').style.display = 'block';
    document.getElementById('students').style.display = 'block';
    document.getElementById('teachers').style.display = 'block';
    document.getElementById('courses').style.display = 'block';

    document.getElementById('#register_professor_course').style.display = 'block';
    document.getElementById('register_professor_course').style.display = 'block';

    document.getElementById('#student_register_requests').style.display = 'block';
    //document.getElementById('student_register_requests').style.display = 'block';
}

function ShowProfessor() {
    document.getElementById('sign_out_professor').style.display = 'block';

    document.getElementById('#edit_professor_profile').style.display = 'block';
    document.getElementById('edit_professor_profile').style.display = 'block';
}

function ShowStudent() {
    document.getElementById('sign_out_student').style.display = 'block';

    document.getElementById('#edit_student_profile').style.display = 'block';
    document.getElementById('edit_student_profile').style.display = 'block';
}

//////////////////////////////////////////////////// LOG IN ////////////////////////////////////////////////////
function LogIn() {
    var user = {
        code: $('#userName').val(),
        password: $('#userPassword').val()
    }
    LoginProfessor(user);
    LoginAdmin(user);
    LoginStudent(user);
}

function LoginAdmin(user) {
    $.ajax({
        url: "/User/LogInAdmin",
        type: "POST",
        data: JSON.stringify(user),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response == 1) {
                return LoginAdminValidate(true);
            }
        }
    });
}

function LoginProfessor(user) {
    $.ajax({
        url: "/User/LogInProfessor",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (response == 1) {
                return LoginProfessorValidate(true);
            }
        }
    });
}

function LoginStudent(user) {
    $.ajax({
        url: "/User/LogInStudent",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (response == 1) {
                return LoginStudentValidate(true);
            }
        }
    });
}

//////////////////////////////////////////////////// LOG IN VALIDATE ////////////////////////////////////////////////////
function LoginAdminValidate(response) {
    if (response == true) {
        ShowAdmin();
        CleanLogIn();
        HideStudentSignIn();
    }
}
function LoginProfessorValidate(response) {
    if (response == true) {
        ShowProfessor();
        CleanLogIn();
        HideStudentSignIn();
    }
}
function LoginStudentValidate(response) {
    if (response == true) {
        ShowStudent();
        CleanLogIn();
        HideStudentSignIn();
    } else {
        document.getElementById("informationLogIn").innerHTML = "Error al ingresar";
        document.getElementById("informationLogIn").style.color = "red";
    }
}

//////////////////////////////////////////////////// CLEAN ////////////////////////////////////////////////////
function CleanLogIn() {
    document.getElementById("userName").value = "";
    document.getElementById("userPassword").value = "";
}

function CleanStudent() {
    document.getElementById("codeS").value = "";
    document.getElementById("nameS").value = "";
    document.getElementById("emailS").value = "";
    document.getElementById("passwordS").value = "";
    document.getElementById("repeatpasswordS").value = "";
}

function CleanProfessor() {
    document.getElementById("nameP").value = "";
    document.getElementById("codeP").value = "";
    document.getElementById("emailP").value = "";
    document.getElementById("AcadGradeP").value = "Grado Académico";
    document.getElementById("passwordP").value = "";
    document.getElementById("repeatpasswordP").value = "";
}

function CleanCourses() {
    document.getElementById("nameC").value = "";
    document.getElementById("codeC").value = "";
    document.getElementById("creditsC").value = "";
    document.getElementById("semesterC").value = "Semestre";
    document.getElementById("yearC").value = "Año de carrera";
}

//////////////////////////////////////////////////// ON CLICK ////////////////////////////////////////////////////
/////////////// GENERAL ///////////////
function RegisterOnClick() {
    document.getElementById('register').style.display = 'block';
    document.getElementById('team').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

/////////////// ADMIN ///////////////

/////////////// PROFESSOR ///////////////
function TeachersOnClick() {
    LoadDataProfessor();
    document.getElementById('team').style.display = 'block';
    document.getElementById('teachers').style.display = 'block';
    document.getElementById('register').style.display = 'none';
    document.getElementById('courses').style.display = 'none';
    document.getElementById('students').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

/////////////// STUDENT ///////////////
function StudentsOnClick() {
    LoadDataStudent();
    document.getElementById('team').style.display = 'block';
    document.getElementById('students').style.display = 'block';
    document.getElementById('teachers').style.display = 'none';
    document.getElementById('register').style.display = 'none';
    document.getElementById('courses').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

function TemporalStudentsOnClick() {
    LoadDataTemporalStudent();
    document.getElementById('team').style.display = 'block';
    document.getElementById('teachers').style.display = 'block';
    document.getElementById('register').style.display = 'none';
    document.getElementById('courses').style.display = 'none';
    document.getElementById('students').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

function EditStudentOnClick() {
    document.getElementById('#edit_student').style.display = 'block';
    document.getElementById('edit_student').style.display = 'block';
}

/////////////// COURSE ///////////////
function CoursesOnClick() {
    LoadDataCourse();
    document.getElementById('team').style.display = 'block';
    document.getElementById('courses').style.display = 'block';
    document.getElementById('teachers').style.display = 'none';
    document.getElementById('register').style.display = 'none';
    document.getElementById('students').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

/////////////// NOTICE ///////////////
function NewNotOnClick() {
    document.getElementById('newNot').style.display = 'block';
    document.getElementById('register').style.display = 'none';
    document.getElementById('team').style.display = 'none';
}

//////////////////////////////////////////////////// API ////////////////////////////////////////////////////
function previewFile() {
    var preview = document.querySelector('#image');
    var file = document.querySelector('input[type=file]').files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        preview.src = reader.result;
    }
    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}

//////////////////////////////////////////////////// AJAX FUNCTIONALITIES ////////////////////////////////////////////////////
/////////////// ADMIN ///////////////


/////////////// PROFESSOR ///////////////
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
            CleanProfessor();
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

    var respuesta = confirm("¿Quieres eliminar a este profesor?");
    if (respuesta) {
        $.ajax({ //Simbolo de dolar todo lo de jquery
            url: "/Professor/Remove",
            data: JSON.stringify(id),
            type: "DELETE",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //aca recibo el resultafo del backend (datos,objetos,mensajes)
                //alert("ELIMINADO");
                LoadDataProfessor();
            },
            error: function (errorMessage) {
                alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }
}

/////////////// STUDENT ///////////////
function AddStudent() {
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
            CleanStudent();
        },
        error: function (errorMessage) {
            // alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

function AddTemporalStudent() {

    var student = {
        code: $('#codeS').val(),
        name: $('#nameS').val(),
        email: $('#emailS').val(),
        password: $('#passwordS').val()
    };

    $.ajax({
        url: "/Student/AddTemporal",
        data: JSON.stringify(student),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            CleanStudent();
            document.getElementById("information").innerHTML = "Su solicitud se ha enviado correctamente";
            document.getElementById("information").style.color = "green";

        },
        error: function (errorMessage) {
            document.getElementById("information").innerHTML = "El usuario ya está registrado en el sistema";
            document.getElementById("information").style.color = "red";
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
                html += '<td><a href="#myModalEliminate" data-toggle="modal" data-target="#myModalEliminate">Editar</a> | <a href="#students" onclick="Remove(' + item.id + ')">Eliminar</a></td>';
            });
            $('.tbodyStudent').html(html);
        })
}

function LoadDataTempStudent() {
    $.ajax({
        url: "/Student/GetTemporalStudents",

        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                document.getElementById("idTemp").value = item.id;
                html += '<td>' + item.code + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td><a href="#students" onclick="return AceptStudent(' + item.id + ')">Aceptar</a> | <a href="#students" onclick="RevokeStudent(' + item.id + ')">Denegar</a></td>';
            });
            $('.tbodyTemporalStudent').html(html);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

function RemoveStudent(id) {
    var respuesta = confirm("¿Quieres eliminar a este estudiante?");
    if (respuesta) {
        $.ajax({ 
            url: "/Student/Remove",
            data: JSON.stringify(id),
            type: "DELETE",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                LoadDataStudent();
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        })
    }
}

function RemoveTemporalStudent(id) {
   
    $.ajax({
        url: "/Student/Remove",
        data: JSON.stringify(id),
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataStudent();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
    
}

function UpdateStudent() {

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

            LoadData();
            CloseEdit()
        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);
        }
    });
}

/////////////// COURSE ///////////////
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
            CleanCourses();
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

    var respuesta = confirm("¿Quieres eliminar a este curso?");
    if (respuesta) {

        $.ajax({ //Simbolo de dolar todo lo de jquery
            url: "/Course/Remove",
            data: JSON.stringify(id),
            type: "DELETE",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                //aca recibo el resultafo del backend (datos,objetos,mensajes)
                LoadDataCourse();
            },
            error: function (errorMessage) {
                alert("Error");
                alert(errorMessage.responseText);
            }
        });
    }

}

//////////////////////////////////////////////////// GENERAL FUNCTIONS ////////////////////////////////////////////////////
function CloseEdit() {
    document.getElementById("edit").style.display = 'none';
}