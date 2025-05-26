using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.User;

namespace MovieApp.Handlers.Review.Delete;

public class DeleteReviewHandler : IRequestHandler<DeleteReviewRequest>
{
    private readonly MovieAppDbContext _context;
    private readonly IUserInfoService _userInfoService;

    public DeleteReviewHandler(MovieAppDbContext context, IUserInfoService userInfoService)
    {
        _context = context;
        _userInfoService = userInfoService;
    }

    public async Task Handle(DeleteReviewRequest request, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews.FindAsync(request.Id) ?? throw new BadRequestException($"Отзыв {request.Id} не найден");

        var userInfo = _userInfoService.UserJwtInfoDto;
        if (review.CreatedByUserId != userInfo.UserId && !userInfo.IsAdmin)
        {
            throw new ForbiddenException($"Недостаточно прав");
        }

        _context.Remove(review);

        _context.SaveChanges();
    }
}
