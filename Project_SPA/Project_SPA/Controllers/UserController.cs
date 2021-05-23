using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_SPA.Models.Data;
using Project_SPA.Models.Domain;
using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_SPA.Controllers
{
    public class UserController : Controller
    {
        
        StudentDAO studentDAO;
        ProfessorDAO professorDAO;
        AdminDAO adminDAO;

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult LogInAdmin([FromBody] User user)
        {
            adminDAO = new AdminDAO();
            if (adminDAO.GetAdminByCode(user.Code) != null)
            {
                if (ValidateProfessor(adminDAO.GetAdminByCode(user.Code), user))
                {
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
                    return Ok(1);
                }
            }

            return Ok(0);
        }

        public ActionResult LogInProfessor([FromBody] User user)
        {
            professorDAO = new ProfessorDAO();
            if (professorDAO.GetProfessorByCode(user.Code) != null)
            {
                if (ValidateProfessor(professorDAO.GetProfessorByCode(user.Code), user))
                {
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
                    return Ok(1);
                }
            }
            return Ok(0);
        }

        public Boolean ValidateProfessor(Professor professor, User user)
        {
            if (professor.Code.Equals(user.Code) && professor.Password.Equals(user.Password))
            {
                return true;
            }
            return false;
        }

        public ActionResult LogInStudent([FromBody] User user)
        {            
            studentDAO = new StudentDAO();
            if (studentDAO.GetStudentByCode(user.Code) != null)
            {
                if (ValidateStudent(studentDAO.GetStudentByCode(user.Code), user))
                {
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
                    return Ok(1);
                }
            }
            return Ok(0);
        }

        public Boolean ValidateStudent(Student student, User user)
        {
            if (student.Code.Equals(user.Code) && student.Password.Equals(user.Password))
            {
                return true;
            }
            return false;
        }
        
    }
}
