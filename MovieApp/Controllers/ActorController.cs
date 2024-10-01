using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.Actors.Create;
using MovieApp.Handlers.Actors.Delete;
using MovieApp.Handlers.Actors.Get;
using MovieApp.Handlers.Actors.GetImage;
using MovieApp.Handlers.Actors.GetList;
using MovieApp.Handlers.Actors.Update;
using MovieApp.Handlers.Actors.UploadImage;
using MovieApp.Infrastucture.Controller;
using MovieApp.Infrastucture.Controller.Auth;

namespace MovieApp.Controllers
{
    [Route("Actor")]
    
    public class ActorController : BaseController
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] GetActorRequest requets)
        {
            return Ok(await MediatR.Send(requets));
        }

        [HttpGet("{actorId:guid}/Photo")]
        public async Task<IActionResult> GetPhoto([FromRoute] GetActorImageRequest requets)
        {
            return File(await MediatR.Send(requets), "image/*");
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetActorsListRequest requets)
        {
            return Ok(await MediatR.Send(requets));
        }

        [HttpPost]
        [CustomAuthorizationFilter(isAdmin: true)]
        public async Task<IActionResult> Create([FromBody] CreateActorRequets requets)
        {
            
            return Ok(await MediatR.Send(requets));
        }

        [HttpPost("{actorId:guid}/Photo")]
        [CustomAuthorizationFilter(isAdmin: true)]
        public async Task<IActionResult> UploadPhoto(ActorUploadImageRequest requets)
        {
            await MediatR.Send(requets);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [CustomAuthorizationFilter(isAdmin: true)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateActorRequest requets)
        {
            requets.Id = id;
            return Ok(await MediatR.Send(requets));
        }

        [HttpDelete("{id:guid}")]
        [CustomAuthorizationFilter(isAdmin: true)]
        public async Task<IActionResult> Delete([FromRoute] DeleteActorRequest requets)
        {
            await MediatR.Send(requets);
            return Ok();
        }
    }
}
