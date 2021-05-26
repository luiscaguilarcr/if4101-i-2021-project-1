using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_SPA.Models.Data;
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

        // GET: ProfessorController
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


        public ActionResult Edit([FromBody] Professor professor)
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.Edit(professor));
        }


        public ActionResult Remove([FromBody] int id) //DISTINTA AL PROFE
        {
            professorDAO = new ProfessorDAO(_context);
            return Ok(professorDAO.Remove(id));
        }

        public Boolean ValidateProfessor(Professor professor)
        {

            professorDAO = new ProfessorDAO(_context);
            List<Professor> professors = professorDAO.GetProfessor();
            foreach (Professor profesor in professors)
            {
                if (profesor.Code.Equals(profesor.Code))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
