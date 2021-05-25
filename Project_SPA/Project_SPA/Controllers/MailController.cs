using MailKit;
using Microsoft.AspNetCore.Mvc;
using Project_SPA.Models.Data;
using Project_SPA.Models.Domain;
using Project_SPA.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Project_SPA.Controllers
{
    [Route("api/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IF4101_2021_SPAContext _context;
        StudentDAO studentDAO;

        private readonly Models.Domain.IMailService mailService;
        public MailController(Models.Domain.IMailService mailService)
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
        
    }
}
