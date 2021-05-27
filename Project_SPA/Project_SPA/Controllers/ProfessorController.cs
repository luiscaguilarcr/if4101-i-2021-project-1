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
    public class ProfessorController : Controller
    {

        private readonly IF4101_2021_SPAContext _context;
        ProfessorDAO professorDAO;

        public ProfessorController(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEF()
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.GetEF());
        }

        public ActionResult GetProfessor()
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.GetProfessor());
        }

        public ActionResult Add([FromBody] Professor professor)
        {
            if (ValidateProfessor(professor)) { 
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.Add(professor));
            
            }

            return Ok(-1);
        }

        public ActionResult LoadProfile()
        {
            professorDAO = new ProfessorDAO(_context);

            return Ok(professorDAO.GetProfessorByCode(JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser")).Code));
        }

        public ActionResult Edit([FromBody] Professor professor)
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.Edit(professor));
        }
        public ActionResult EditProfile([FromBody] Professor professor)
        {
            if (ValidateEditProfile(professor)) { 
                professorDAO = new ProfessorDAO(_context);
                Professor professor1 = professorDAO.GetProfessorByCode(JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser")).Code);
                professor.Id = professor1.Id;
                professor.Code = professor1.Code;
                professor.Email = professor1.Email;
                professor.CreationUser = professor1.CreationUser;
                professor.UpdateUser = professor1.Code;

                if(professor.AcademicDegreeId == 0)
                {
                    professor.AcademicDegreeId = professor1.AcademicDegreeId;
                }
                return Ok(professorDAO.Edit(professor));
            }
            return Ok();
        }

        public ActionResult Remove([FromBody] int id) 
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.Remove(id));
        }

        public Boolean ValidateProfessor(Professor newProfessor)
        {
            if (newProfessor == null || newProfessor.Code == null || newProfessor.Name == null || newProfessor.Password == null)
            {
                return false;
            }
            professorDAO = new ProfessorDAO(_context);
            List<Professor> professors = professorDAO.GetProfessor();
            foreach (Professor professor in professors)
            {
                if (professor.Email.Equals(newProfessor.Email))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean ValidateEditProfile(Professor professor)
        {
            if (professor == null || professor.Name == null || professor.Password == null)
            {
                return false;
            }

            return true;
        }
    }

}
