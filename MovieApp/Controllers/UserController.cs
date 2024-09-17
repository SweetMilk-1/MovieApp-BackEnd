using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.User.Authentication;
using MovieApp.Handlers.User.Registration;
using MovieApp.Infrastucture.Controller;

namespace MovieApp.Controllers
{
    [Route("User")]
    public class UserController : BaseController
    {
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserRequest request)
        {
            await MediatR.Send(request);
            return Created();
        }

        [HttpPost("Authentication")]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationRequest request)
        {
            return Ok(await MediatR.Send(request));
        }
    }
}
