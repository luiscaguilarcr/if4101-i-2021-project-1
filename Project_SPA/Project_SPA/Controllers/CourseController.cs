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
    public class CourseController : Controller
    {
        private readonly IF4101_2021_SPAContext _context;
        CourseDAO courseDAO;

        public CourseController(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEF()
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.GetEF());
        }

        public ActionResult GetCourse()
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.GetCourse());
        }

        public ActionResult Add([FromBody] Course course)
        {
            if (ValidateNewCurse(course)) { 
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.Add(course));
            }
            return Ok(-1);
            
        }


        public ActionResult Edit([FromBody] Course course)
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.Edit(course));
        }


        public ActionResult Remove([FromBody] int id)
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.Remove(id));
        }

        public Boolean ValidateNewCurse(Course course)
        {
            courseDAO = new CourseDAO(_context);
            List<Course> courses = courseDAO.GetCourse();
            foreach (Course coursee in courses)
            {

                if (course.Code.Equals(course.Code))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
