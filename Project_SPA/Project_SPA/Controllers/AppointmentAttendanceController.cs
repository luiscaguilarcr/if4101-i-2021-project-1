using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_SPA.Models.Data;
using Project_SPA.Models.Domain;
using Project_SPA.Models.Entities;

namespace Project_SPA.Controllers
{
    public class AppointmentAttendanceController : Controller
    {
        // GET: AppointmentController

        private readonly IF4101_2021_SPAContext _context;
        StudentDAO studentDAO;
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

        public List<Entities.Student> GetCourse()
        {
            List<Entities.Student> students = null;

            using (var context = new IF4101_2021_SPAContext())
            {
                students = context.Students.Select(studentItem => new Entities.Student()
                {
                    Id = studentItem.Id,
                    Code = studentItem.Code,
                    Name = studentItem.Name,
                    Email = studentItem.Email,
                    Password = studentItem.Password

                }).ToList<Entities.Student>();
            }

            return students;
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
