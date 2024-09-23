using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.Movie.Create;
using MovieApp.Infrastucture.Controller;

namespace MovieApp.Controllers
{
    [Route("Movie")]
    public class MovieController : BaseController
    {
        [HttpGet()]
        public async Task<IActionResult> GetList()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
        {
            await MediatR.Send(request);
            return Created();
        }
    }
}
