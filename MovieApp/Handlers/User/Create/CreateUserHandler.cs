using MediatR;
using MovieApp.Database;
using MovieApp.Services.Security;


namespace MovieApp.Handlers.User.Create
{
    internal class CreateUserHandler : IRequestHandler<CreateUserRequest>
    {

        private readonly MovieAppDbContext _dbContext;
        private readonly ICryptoService _cryptoService;

        public CreateUserHandler(
            MovieAppDbContext dbContext,
            ICryptoService cryptoService)
        {
            _dbContext = dbContext;
            _cryptoService = cryptoService;
        }

        public async Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new Database.Entities.User
            {
                Email = request.Email,
                IsAdmin = false,
                IsApproved = true,
                Login = request.Login,
                PasswordHash = _cryptoService.GetHashFromString(request.Password)
            };

            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
