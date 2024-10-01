using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.Files;

namespace MovieApp.Handlers.User.GetImage
{
    public class GetUserImageHandler : IRequestHandler<GetUserImageRequest, byte[]>
    {
        private MovieAppDbContext _context;
        private IFileService _fileService;
        public GetUserImageHandler(MovieAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<byte[]> Handle(GetUserImageRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"Пользователь {request.UserId} не найден");
            }

            if (user.ImagePath == null || !File.Exists(user.ImagePath))
            {
                throw new NotFoundException($"У пользователя {request.UserId} нет фотографии");
            }

            return await _fileService.GetFile(user.ImagePath);
        }
    }
}
