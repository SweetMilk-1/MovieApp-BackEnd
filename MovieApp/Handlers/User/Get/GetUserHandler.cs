using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.User.Get
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        private MovieAppDbContext _context;

        private IMapper _mapper;

        public GetUserHandler(MovieAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.UserId) ?? throw new NotFoundException($"Пользователь {request.UserId} не найден");
        }
    }
}
