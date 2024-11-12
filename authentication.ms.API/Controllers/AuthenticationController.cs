using authentication.ms.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace authentication.ms.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IHMacService hMacService;

        public AuthenticationController(IHMacService hMacService)
        {
            this.hMacService = hMacService;
        }

        [HttpPost("authenticate-message")]
        public bool AuthenticateMessage(
             [FromBody] string content,
             [FromHeader(Name = "Signature")] string signature)
        {
            var validated = hMacService.validateAndProcessRequest(content, signature);
            if (!validated)
            {
                return false;
            }
            return true;
        }

    }
}
