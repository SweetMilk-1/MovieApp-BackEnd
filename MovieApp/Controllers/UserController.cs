using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.User.Authentication;
using MovieApp.Handlers.User.GetImage;
using MovieApp.Handlers.User.Registration;
using MovieApp.Handlers.User.UploadImage;
using MovieApp.Infrastucture.Controller;

namespace MovieApp.Controllers
{
    [Route("User")]
    public class UserController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RegistrationUserRequest request)
        {
            await MediatR.Send(request);
            return Created();
        }

        [HttpPost("Authentication")]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationRequest request)
        {
            return Ok(await MediatR.Send(request));
        }

        [HttpPost("UploadPhoto/{userId:guid}")]
        public async Task<IActionResult> UploadPhoto(UserUploadImageRequest request)
        {
            await MediatR.Send(request);
            return Ok();
        }

        [HttpGet("GetPhoto/{userId:guid}")]
        public async Task<IActionResult> GetPhoto(GetUserImageRequest request)
        {
            return File(await MediatR.Send(request), "image/*");
        }
    }
}
