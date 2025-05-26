using Microsoft.AspNetCore.Mvc;
using MovieApp.Handlers.Movie.Update;
using MovieApp.Handlers.Review.Create;
using MovieApp.Handlers.Review.Delete;
using MovieApp.Handlers.Review.GetList;
using MovieApp.Handlers.Review.Update;
using MovieApp.Infrastucture.Controller;
using MovieApp.Infrastucture.Controller.Auth;

namespace MovieApp.Controllers
{
    [Route("Review")]
    public class ReviewController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetReviewsByFilm([FromQuery] GetReviewsRequest request)
        {
            return Ok(await MediatR.Send(request));
        }

        [HttpPut("{id:guid}")]
        [CustomAuthorizationFilter]

        public async Task<IActionResult> UpdateReview([FromRoute] Guid id, [FromBody] UpdateReviewRequest request)
        {
            request.Id = id;
            await MediatR.Send(request);
            return Ok();
        }

        [HttpPost]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> Create([FromBody] CreateReviewRequest request)
        {
            await MediatR.Send(request);
            return Created();
        }

        [HttpDelete("{id:guid}")]
        [CustomAuthorizationFilter]
        public async Task<IActionResult> Delete(DeleteReviewRequest request)
        {
            await MediatR.Send(request);
            return Ok();
        }
    }
}
