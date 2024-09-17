using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Arch.Controller;
using MovieApp.Handlers.User.Registeration;

namespace MovieApp.Controllers
{
    public class UserController : BaseController
    {
        public UserController() { }

        public async Task<IActionResult> Registration(RegistrationUserRequest request)
        {
            return Ok(await MediatR.Send(request));
        }
    }
}
