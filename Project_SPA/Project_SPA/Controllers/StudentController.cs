using Microsoft.AspNetCore.Mvc;
using Project_SPA.Models.Data;
using Project_SPA.Models.Entities;

namespace Project_SPA.Controllers
{
    public class StudentController : Controller
    {
        private readonly IF4101_2021_SPAContext _context;
        StudentDAO studentDAO;
        MailController mailController;

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

        public ActionResult GetTemporal()
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetTemporal());
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

        public ActionResult AcceptTemporal([FromBody] int id)
        {
            studentDAO = new StudentDAO(_context);
            if(studentDAO.GetTemporalStudentById(id) != null)
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

        public ActionResult Remove([FromBody] int id)
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.Remove(id));
        }

        public ActionResult RemoveTemporal([FromBody] int id) 
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.RemoveTemporal(id));
        }
    }
}
