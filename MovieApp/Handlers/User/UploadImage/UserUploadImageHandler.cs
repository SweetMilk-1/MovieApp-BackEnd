using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Entities;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.Files;
using static System.Net.Mime.MediaTypeNames;

namespace MovieApp.Handlers.User.UploadImage
{
    public class UserUploadImageHandler : IRequestHandler<UserUploadImageRequest>
    {
        private MovieAppDbContext _context;
        private IFileService _fileService;

        public UserUploadImageHandler(MovieAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task Handle(UserUploadImageRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                throw new BadRequestException($"Пользователь {request.UserId} не найден");
            }

            var userImagesPath = "/Images/Users";

            var uploadPathDirectory = $"{Directory.GetCurrentDirectory()}{userImagesPath}";
            var fileExtension = Path.GetExtension(request.File.FileName).ToLowerInvariant();
            var fileName = $"user_{request.UserId}{fileExtension}";
            string fullPath = $"{uploadPathDirectory}/{fileName}";

            await _fileService.SaveFile(uploadPathDirectory, fileName, request.File.OpenReadStream());

            user.ImagePath = fullPath;
            await _context.SaveChangesAsync();
        }
    }
}

