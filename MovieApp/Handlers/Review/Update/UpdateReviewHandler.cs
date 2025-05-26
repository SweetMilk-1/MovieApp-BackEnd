using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.User;

namespace MovieApp.Handlers.Review.Update
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewRequest>
    {

        private readonly MovieAppDbContext _context;
        private readonly IUserInfoService _userInfoService;

        public UpdateReviewHandler(MovieAppDbContext context, IUserInfoService userInfoService)
        {
            _context = context;
            _userInfoService = userInfoService;
        }

        public async Task Handle(UpdateReviewRequest request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(request.Id) ?? throw new BadRequestException($"Отзыв {request.Id} не найден");

            if (_userInfoService.UserJwtInfoDto?.UserId != review.CreatedByUserId || !_userInfoService.UserJwtInfoDto.IsAdmin)
            {
                throw new ForbiddenException($"Недостаточно прав");
            }

            review.Grade = request.Grade;
            review.Text = request.Text;

            await _context.SaveChangesAsync();
        }
    }
}
