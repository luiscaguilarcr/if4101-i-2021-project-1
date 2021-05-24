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
//GENERAL
function RegisterOnClick() {
    document.getElementById('register').style.display = 'block';
    document.getElementById('team').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

//ADMIN

//PROFESSOR
function TeachersOnClick() {
    LoadDataProfessor();
    document.getElementById('team').style.display = 'block';
    document.getElementById('teachers').style.display = 'block';
    document.getElementById('register').style.display = 'none';
    document.getElementById('courses').style.display = 'none';
    document.getElementById('students').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

//STUDENT
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

//COURSE
function CoursesOnClick() {
    LoadDataCourse();
    document.getElementById('team').style.display = 'block';
    document.getElementById('courses').style.display = 'block';
    document.getElementById('teachers').style.display = 'none';
    document.getElementById('register').style.display = 'none';
    document.getElementById('students').style.display = 'none';
    document.getElementById('newNot').style.display = 'none';
}

//NOTICE
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
//ADMIN


//PROFESSOR


//STUDENT
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

