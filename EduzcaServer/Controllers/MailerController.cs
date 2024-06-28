using Microsoft.AspNetCore.Mvc;
using Services;

namespace EduzcaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailerController(IMailerService mailerService) : ControllerBase
    {
        private readonly IMailerService _mailerService = mailerService;

        [HttpPost]
        public async Task<ActionResult> SendMail(SendMailDTO mailBody)
        {
            try
            { 
                _mailerService.SendMail(mailBody);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
