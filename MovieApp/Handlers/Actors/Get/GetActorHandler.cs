using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Actors.Get
{
    public class GetActorHandler : IRequestHandler<GetActorRequest, ActorDto>
    {
        private readonly MovieAppDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetActorHandler(MovieAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActorDto> Handle(GetActorRequest request, CancellationToken cancellationToken)
        {
            var actor = await _dbContext.Actors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new NotFoundException($"Актер {request.Id} не найжен");

            return _mapper.Map<ActorDto>(actor);
        }
    }
}
