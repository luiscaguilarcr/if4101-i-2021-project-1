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
    public class StudentController : Controller
    {
        private readonly IF4101_2021_SPAContext _context;
        StudentDAO studentDAO;

        public StudentController(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEF()
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetEF());
        }

        public ActionResult GetStudents()
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetStudents());
        }

        public ActionResult Add([FromBody] Student student)
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.Add(student));
        }

        public ActionResult AddTemporal([FromBody] TemporalStudent student)
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.AddTemporal(student));
        }

        public ActionResult Edit([FromBody] Student student)
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.Edit(student));
        }


        public ActionResult Remove([FromBody] int id) //DISTINTA AL PROFE
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.Remove(id));
        }
    }
}
