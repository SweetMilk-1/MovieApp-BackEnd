using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.User.Authentication;
using MovieApp.Handlers.User.Create;
using MovieApp.Handlers.User.Get;
using MovieApp.Handlers.User.GetImage;
using MovieApp.Handlers.User.UploadImage;
using MovieApp.Infrastucture.Controller;

namespace MovieApp.Controllers
{
    [Route("User")]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            await MediatR.Send(request);
            return Created();
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> Get([FromRoute] GetUserRequest request)
        {
            return Ok(await MediatR.Send(request));
        }

        [HttpGet("{userId:guid}/Photo")]
        public async Task<IActionResult> GetPhoto(GetUserImageRequest request)
        {
            return File(await MediatR.Send(request), "image/*");
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


    }
}
