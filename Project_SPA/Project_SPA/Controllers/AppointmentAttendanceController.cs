using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_SPA.Models.Data;
using Project_SPA.Models.Domain;
using Project_SPA.Models.Entities;
using System;
using System.Collections.Generic;

namespace Project_SPA.Controllers
{
    public class AppointmentAttendanceController : Controller
    {
        // GET: AppointmentController

        private readonly IF4101_2021_SPAContext _context;
        StudentDAO studentDAO;
        CourseDAO courseDAO;
        StudentCourseGroupDAO studentCourseGroupDAO;
        ProfessorCourseGroupDAO professorCourseGroupDAO;
        AppointmentAttendanceDAO appointmentAttendanceDAO;


        public AppointmentAttendanceController(IF4101_2021_SPAContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: AppointmentController/Create
        public ActionResult Create([FromBody] AppointmentAttendance appointment )
        {
            studentDAO = new StudentDAO(_context);
            Student student = GetSessionStudent();
            
            appointment.StudentId = student.Id;

            appointmentAttendanceDAO = new AppointmentAttendanceDAO(_context);

            int response = appointmentAttendanceDAO.Add(appointment);

            return Ok(response);
        }

        public List<Course> GetCourseByStudent(int id)
        {
            studentCourseGroupDAO = new StudentCourseGroupDAO(_context);
            courseDAO = new CourseDAO(_context);
            List<StudentCourseGroup> studentCourseGroups = studentCourseGroupDAO.GetStudentsCourseGroup();
            List<Course> courses = new List<Course>();

            foreach(StudentCourseGroup studentCourseGroup in studentCourseGroups)
            {
                if (studentCourseGroup.StudentId == id)
                {
                    courses.Add(courseDAO.GetCourseById(studentCourseGroup.CourseId));
                }
            }
            return courses;
        }

        public List<Group> GetGroupByStudent(int id)
        {
            try
            {
                studentCourseGroupDAO = new StudentCourseGroupDAO(_context);
                List<StudentCourseGroup> studentCourseGroups = studentCourseGroupDAO.GetStudentsCourseGroup();
                List<Group> groups = new List<Group>();

                foreach (StudentCourseGroup studentCourseGroup in studentCourseGroups)
                {
                    if (studentCourseGroup.StudentId == id)
                    {
                        groups.Add(studentCourseGroupDAO.GetGroupById(studentCourseGroup.CourseId));
                    }
                }

                return groups;
            }
            catch
            {
                return null;
            }

        }

        public List<Course> GetCourseByProfessor(int id)
        {
            professorCourseGroupDAO = new ProfessorCourseGroupDAO(_context);
            courseDAO = new CourseDAO(_context);
            List<ProfessorCourseGroup> professorCourseGroups = professorCourseGroupDAO.GetProfessorCourseGroup();
            List<Course> courses = new List<Course>();

            foreach (ProfessorCourseGroup professorCourseGroup in professorCourseGroups)
            {
                if (professorCourseGroup.ProfessorId == id)
                {
                    courses.Add(courseDAO.GetCourseById(professorCourseGroup.CourseId));
                }
            }
            return courses;
        }

        public List<Group> GetGroupByProfessor(int id)
        {
            try
            {
                professorCourseGroupDAO = new ProfessorCourseGroupDAO(_context);
                List<ProfessorCourseGroup> professorCourseGroups = professorCourseGroupDAO.GetProfessorCourseGroup();
                List<Group> groups = new List<Group>();

                foreach (ProfessorCourseGroup professorCourseGroup in professorCourseGroups)
                {
                    if (professorCourseGroup.ProfessorId == id)
                    {
                        groups.Add(studentCourseGroupDAO.GetGroupById(professorCourseGroup.CourseId));
                    }
                }

                return groups;
            }
            catch
            {
                return null;
            }

        }

        // GET: AppointmentController/Edit/5
        public ActionResult Edit([FromBody] int id)
        {
            return View();
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete([FromBody] int id)
        {
            return View();
        }


        private Student GetSessionStudent()
        {
            studentDAO = new StudentDAO(_context);
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

            return studentDAO.GetStudentByCode(user.Code);
        }
    }
}
