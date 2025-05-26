using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Entities;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.User;

namespace MovieApp.Handlers.Review.Create
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewRequest, Guid>
    {
        private readonly MovieAppDbContext _context;
        private readonly IUserInfoService _userInfoService;
        private readonly IMapper _mapper;
        public CreateReviewHandler(MovieAppDbContext context, IUserInfoService userInfoService, IMapper mapper)
        {
            _context = context;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateReviewRequest request, CancellationToken cancellationToken)
        {
            var userId = _userInfoService.UserJwtInfoDto.UserId;
            if (_context.Reviews.Any(x => x.MovieId == request.MovieId && x.CreatedByUserId == userId))
                throw new BadRequestException($"У вас уже есть отзыв на фильм");

            var review = _mapper.Map<Database.Entities.Review>(request);
            review.CreatedByUserId = userId;

            _context.Add(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }
    }
}
