using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastucture.Controller;

namespace MovieApp.Controllers
{
    [Route("Movie")]
    [Authorize]
    public class MovieController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok();
        }
    }
}
