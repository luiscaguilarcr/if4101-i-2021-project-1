using Microsoft.AspNetCore.Mvc;
using Project_SPA.Mail.Domain;
using Project_SPA.Models.Data;
using Project_SPA.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Project_SPA.Controllers
{
    [Route("api/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly IF4101_2021_SPAContext _context;

        StudentDAO studentDAO;
        ProfessorDAO professorDAO;
        CourseDAO courseDAO;
        AppointmentAttendanceDAO appointmentAttendanceDAO;

        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("sendRequestEmail")]
        public async Task<ActionResult> SendRequestMail([FromBody] string email)
        {
            try
            {
                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = email,
                    Subject = "Sistema de chat UCR del Recinto de Paraíso",
                    Body = "El sistema de chat UCR del Recinto de Paraíso de la carrera Informática Empresarial ha registrado su solicitud satisfactoriamente, por favor, espere a que el coordinador de la carrera admita su ingreso, en un tiempo hábil de 1-3 días laborales."
                };

                await mailService.SendEmailAsync(mailRequest);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

        
        [HttpPost("sendAcceptanceMail")]
        public async Task<IActionResult> SendAcceptanceMail([FromBody] int id)
        {
            try
            {
                studentDAO = new StudentDAO(_context);
                TemporalStudent student = studentDAO.GetTemporalStudentById(id);
                
                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = student.Email,
                    Subject = "Sistema de chat UCR del Recinto de Paraíso",
                    Body = "Bienvenido, usted ha sido aceptado en el sistema de chat UCR del Recinto de Paraíso de la carrera Informática Empresarial"
                };

                await mailService.SendEmailAsync(mailRequest);
                return Ok(1);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("sendRequestAppointmentAttendanceStudentEmail")]
        public async Task<ActionResult> SendRequestAppointmentAttendanceEmail([FromBody] AppointmentAttendance appointmentAttendance)
        {
            try
            {
                studentDAO = new StudentDAO(_context);
                professorDAO = new ProfessorDAO(_context);

                Student student = studentDAO.GetStudentById(appointmentAttendance.StudentId);
                Professor professor = professorDAO.GetProfessorById(appointmentAttendance.ProfessorId);
                Course course = courseDAO.GetCourseById(appointmentAttendance.CourseId);

                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = student.Email,
                    Subject = "Sistema de chat UCR del Recinto de Paraíso",
                    Body = "Usted ha solicitado la hora de consulta con el profesor " + professor.Name +
                    ".\nCurso :" + course.Name +
                    ".\nFecha: " + appointmentAttendance.StartDateHour.Day + "/" + appointmentAttendance.StartDateHour.Month + "/" + appointmentAttendance.StartDateHour.Year +
                    ".\nHora: " + appointmentAttendance.StartDateHour.Hour + ":" + appointmentAttendance.StartDateHour.Minute +
                    ".\nRecuerde que el profesor dispone de 1-3 días hábiles para responder su solicitud."
                    
                };

                await mailService.SendEmailAsync(mailRequest);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("sendRequestAppointmentAttendanceProfessorEmail")]
        public async Task<ActionResult> SendRequestAppointmentAttendanceProfessorEmail([FromBody] int appointmentAttendanceId)
        {
            try
            {
                appointmentAttendanceDAO = new AppointmentAttendanceDAO(_context);
                studentDAO = new StudentDAO(_context);
                professorDAO = new ProfessorDAO(_context);

                AppointmentAttendance appointmentAttendance = appointmentAttendanceDAO.GetById(appointmentAttendanceId);
                Student student = studentDAO.GetStudentById(appointmentAttendance.StudentId);
                Professor professor = professorDAO.GetProfessorById(appointmentAttendance.ProfessorId);
                Course course = courseDAO.GetCourseById(appointmentAttendance.CourseId);

                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = professor.Email,
                    Subject = "Sistema de chat UCR del Recinto de Paraíso",
                    Body = "Usted ha recibido una solicitud para hora de consulta con el estudiante " + student.Name +
                    ".\nCurso :" + course.Name +
                    ".\nFecha: " + appointmentAttendance.StartDateHour.Day + "/" + appointmentAttendance.StartDateHour.Month + "/" + appointmentAttendance.StartDateHour.Year +
                    ".\nHora: " + appointmentAttendance.StartDateHour.Hour + ":" + appointmentAttendance.StartDateHour.Minute +
                    ".\nPara poder hacer activa esta hora de consulta, debe aceptarla en el sistema, de lo contrario se descartará"

                };

                await mailService.SendEmailAsync(mailRequest);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost("sendAcceptanceAppointmentAttendanceStudentMail")]
        public async Task<IActionResult> SendAcceptanceAppointmentAttendanceStudentMail([FromBody] int appointmentAttendanceId)
        {
            try
            {
                appointmentAttendanceDAO = new AppointmentAttendanceDAO(_context);
                studentDAO = new StudentDAO(_context);
                professorDAO = new ProfessorDAO(_context);
                courseDAO = new CourseDAO(_context);

                AppointmentAttendance appointmentAttendance = appointmentAttendanceDAO.GetById(appointmentAttendanceId);

                Student student = studentDAO.GetStudentById(appointmentAttendance.StudentId);
                Professor professor = professorDAO.GetProfessorById(appointmentAttendance.ProfessorId);
                Course course = courseDAO.GetCourseById(appointmentAttendance.CourseId);
                
                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = student.Email,
                    Subject = "Sistema de chat UCR del Recinto de Paraíso",
                    Body = "Se ha confirmado la hora asistencia con el profesor " + professor.Name +
                    ".\nCurso :" + course.Name +
                    ".\nFecha: " + appointmentAttendance.StartDateHour.Day + "/" + appointmentAttendance.StartDateHour.Month + "/" + appointmentAttendance.StartDateHour.Year +
                    ".\nHora: " + appointmentAttendance.StartDateHour.Hour +":"+ appointmentAttendance.StartDateHour.Minute,
                };

                await mailService.SendEmailAsync(mailRequest);
                return Ok(1);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
