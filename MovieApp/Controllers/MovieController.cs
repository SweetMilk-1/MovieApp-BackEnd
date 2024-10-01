using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.Actors.GetImage;
using MovieApp.Handlers.Actors.Update;
using MovieApp.Handlers.Movie.Create;
using MovieApp.Handlers.Movie.Delete;
using MovieApp.Handlers.Movie.Get;
using MovieApp.Handlers.Movie.GetImage;
using MovieApp.Handlers.Movie.GetList;
using MovieApp.Handlers.Movie.Update;
using MovieApp.Handlers.Movie.UploadImage;
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

        [HttpGet("{movieId:guid}/Photo")]
        public async Task<IActionResult> GetPhoto([FromRoute] GetMovieImageRequest requets)
        {
            return File(await MediatR.Send(requets), "image/*");
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
            return Ok(await MediatR.Send(request));
        }

        [HttpPost("{movieId:guid}/Photo")]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> UploadPhoto(MovieUploadImageRequest request)
        {
            await MediatR.Send(request);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
        {
            request.Id = id;
            return Ok(await MediatR.Send(request));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteMovieRequest request)
        {
            await MediatR.Send(request);
            return Ok();
        }
    }
}
