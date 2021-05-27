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
            if (ValidateEditProfile(student)) { 
                studentDAO = new StudentDAO(_context);
                Student student1 = studentDAO.GetStudentByCode(JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser")).Code);

                student.Id = student1.Id;
                student.Code = student1.Code;
                student.Email = student1.Email;
                student.CreationUser = student1.CreationUser;
                student.UpdateUser = student1.Code;

   
                return Ok(studentDAO.Edit(student));
            }
            return Ok();
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
        public Boolean ValidateNewStudent(TemporalStudent newTemporalStudent)
        {
            studentDAO = new StudentDAO(_context);
            List<Student> students = studentDAO.GetStudents();
            foreach (Student student in students)
            {
                if(newTemporalStudent == null || newTemporalStudent.Code == null || newTemporalStudent.Email == null || newTemporalStudent.Name == null || newTemporalStudent.Password == null)
                {
                    return false;
                }else if (student.Code.Equals(newTemporalStudent.Code))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean ValidateNewTemporalStudent(TemporalStudent newTemporalStudent)
        {
            if (newTemporalStudent == null || newTemporalStudent.Code == null || newTemporalStudent.Email == null || newTemporalStudent.Name == null || newTemporalStudent.Password == null)
            {
                return false;
            }

            studentDAO = new StudentDAO(_context);
            List<TemporalStudent> temporalStudents = studentDAO.GetTemporalStudents();
            foreach (TemporalStudent temoporalStudent in temporalStudents)
            {
                if (temoporalStudent.Code.Equals(newTemporalStudent.Code))
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean ValidateEditProfile(Student student)
        {
            if (student == null || student.Name == null || student.Password == null)
            {
                return false;
            }
            
            return true;
        }
    }
}
