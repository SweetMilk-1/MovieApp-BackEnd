using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.Genre.Create;
using MovieApp.Handlers.Genre.Delete;
using MovieApp.Handlers.Genre.GetList;
using MovieApp.Handlers.Genre.Update;
using MovieApp.Infrastucture.Controller;

namespace MovieApp.Controllers
{
    [Route("Genre")]
    public class GenreController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreRequest request)
        {
            await MediatR.Send(request);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetGenresListRequest request)
        {
            return Ok(await MediatR.Send(request));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGenreRequest request)
        {
            request.Id = id;
            await MediatR.Send(request);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(DeleteGenreRequest request)
        {
            await MediatR.Send(request);
            return Ok();
        }
    }
}
