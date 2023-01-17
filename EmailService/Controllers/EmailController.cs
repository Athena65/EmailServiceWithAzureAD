using EmailService.Models;
using EmailService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{

    [Route("[action]")]
    public class EmailController : Controller
    {
        private readonly IMailService _mailService;

        public EmailController(IMailService mailService)
        {
            _mailService = mailService;
        }
        [HttpGet]
        public async Task<IActionResult> SentEmail(GraphMail mail)
        {
            try
            {
                await _mailService.SendAsync(mail);
                return Ok("Message Sent!" );
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message= ex.Message;
                return BadRequest(response);
            }
        }
    }
}
