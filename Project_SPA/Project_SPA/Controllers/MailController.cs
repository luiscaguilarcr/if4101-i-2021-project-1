using MailKit;
using Microsoft.AspNetCore.Mvc;
using Project_SPA.Models.Domain;
using Project_SPA.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Project_SPA.Controllers
{
    [Route("api/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly Models.Domain.IMailService mailService;
        public MailController(Models.Domain.IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("sendRequestEmail")]
        public async Task<ActionResult> SendRequestMail([FromBody] TemporalStudent student)
        {
            try
            {
                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = student.Email,
                    Subject = "Sistema de chat UCR del Recinto de Paraíso",
                    Body = "El sistema de chat UCR del Recinto de Paraíso ha registrado su solicitud satisfactoriamente, por favor, espere a que el coordinador de la carrera admita su ingreso, en un tiempo hábil de 1-3 días laborales."
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
        public async Task<IActionResult> SendAcceptanceMail([FromBody] string email)
        {
            try
            {
                MailRequest mailRequest = new MailRequest
                {
                    ToEmail = email,
                    Body = "Bienvenido, usted ha sido aceptado en sistema de chat UCR del Recinto de Paraíso"
                };

                await mailService.SendEmailAsync(mailRequest);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}
