using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.Actors.Create;
using MovieApp.Handlers.Actors.Delete;
using MovieApp.Handlers.Actors.Get;
using MovieApp.Handlers.Actors.GetList;
using MovieApp.Handlers.Actors.Update;
using MovieApp.Infrastucture.Controller;

namespace MovieApp.Controllers
{
    [Route("Actor")]
    public class ActorController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActorRequets requets)
        {
            requets.Id = null;
            await MediatR.Send(requets);
            return Created();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] GetActorRequest requets)
        {
            return Ok(await MediatR.Send(requets));
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetActorsListRequest requets)
        {
            return Ok(await MediatR.Send(requets));
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateActorRequest requets)
        {
            requets.Id = id;
            await MediatR.Send(requets);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteActorRequest requets)
        {
            await MediatR.Send(requets);
            return Ok();
        }
    }
}
