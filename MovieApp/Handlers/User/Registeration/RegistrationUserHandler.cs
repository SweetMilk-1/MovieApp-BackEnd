using MediatR;

namespace MovieApp.Handlers.User.Registeration
{
    internal class RegistrationUserHandler : IRequestHandler<RegistrationUserRequest, RegistrationUserResponse>
    {

        private readonly MovieAppDbContext _dbContext;

        public RegistrationUserHandler(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<RegistrationUserResponse> Handle(RegistrationUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
