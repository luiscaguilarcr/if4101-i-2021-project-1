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

        public ActionResult GetById([FromBody] int id)
        {

            studentDAO = new StudentDAO(_context);
            if (studentDAO.GetStudentById(id) != null)
            {
                Student student = studentDAO.GetStudentById(id);

                Student student1 = new Student
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Code = student.Code,
                    Password = student.Password
                };

                return Ok(student1);
            }

            return Ok(0);
        }

        public ActionResult GetTemporal()
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetTemporal());
        }

        public ActionResult LoadProfile()
        {
            studentDAO = new StudentDAO(_context);

            return Ok(studentDAO.GetStudentByCode(JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser")).Code));
        }

        public ActionResult Add([FromBody] Student student)
        {
            
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.Add(student));
        }

        public ActionResult AddTemporal([FromBody] TemporalStudent student)
        {
            if (ValidateNewStudent(student) && ValidateNewTemporalStudent(student)) { 
            studentDAO = new StudentDAO(_context);

            return Ok(studentDAO.AddTemporal(student));
            }
            return Ok(-1);
        }

        public ActionResult AcceptTemporal([FromBody] int id)
        {
            studentDAO = new StudentDAO(_context);
            if (studentDAO.GetTemporalStudentById(id) != null)
            {
                TemporalStudent temporalStudent = studentDAO.GetTemporalStudentById(id);

                Student student = new Student
                {
                    Name = temporalStudent.Name,
                    Email = temporalStudent.Email,
                    Code = temporalStudent.Code,
                    Password = temporalStudent.Password
                };
                studentDAO.Add(student);
                return Ok(1);
            }

            return Ok(0);
        }

        public ActionResult Edit([FromBody] Student student)
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.Edit(student));
        }

        public ActionResult EditProfile([FromBody] Student student)
        {
            studentDAO = new StudentDAO(_context);

            student.Id = studentDAO.GetStudentByCode(JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser")).Code).Id;

            return Ok(studentDAO.Edit(student));
        }

        public ActionResult Remove([FromBody] int id) //DISTINTA AL PROFE
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.Remove(id));
        }

        public ActionResult RemoveTemporal([FromBody] int id)
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.RemoveTemporal(id));
        }

        // Validation
        public Boolean ValidateNewStudent(TemporalStudent temporalStudent)
        {

            studentDAO = new StudentDAO(_context);
            List<Student> students = studentDAO.GetStudents();
            foreach (Student student in students)
            {

                if (student.Code.Equals(temporalStudent.Code))
                {

                    return false;
                }
            }
            return true;
        }

        public Boolean ValidateNewTemporalStudent(TemporalStudent temporalStudent)
        {

            studentDAO = new StudentDAO(_context);
            List<TemporalStudent> students = studentDAO.GetTemporalStudents();
            foreach (TemporalStudent student in students)
            {

                if (student.Code.Equals(temporalStudent.Code))
                {

                    return false;
                }
            }
            return true;
        }
    }
}
