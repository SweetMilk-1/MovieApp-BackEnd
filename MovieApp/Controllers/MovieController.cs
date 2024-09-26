using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.Actors.Update;
using MovieApp.Handlers.Movie.Create;
using MovieApp.Handlers.Movie.Delete;
using MovieApp.Handlers.Movie.Get;
using MovieApp.Handlers.Movie.GetList;
using MovieApp.Handlers.Movie.Update;
using MovieApp.Infrastucture.Controller;
using MovieApp.Infrastucture.Controller.Auth;

namespace MovieApp.Controllers
{
    [Route("Movie")]
    public class MovieController : BaseController
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] GetMovieRequest request)
        {
            return Ok(await MediatR.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetMoviesListRequest request)
        {
            return Ok(await MediatR.Send(request));
        }

        [HttpPost]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
        {
            await MediatR.Send(request);
            return Created();
        }

        [HttpPut("{id:guid}")]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
        {
            request.Id = id;
            await MediatR.Send(request);
            return Created();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteMovieRequest request)
        {
            await MediatR.Send(request);
            return Ok();
        }
    }
}
