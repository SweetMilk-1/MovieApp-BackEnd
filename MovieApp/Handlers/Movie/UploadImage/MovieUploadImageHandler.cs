using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Entities;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.Files;
using MovieApp.Services.User;
using static System.Net.Mime.MediaTypeNames;

namespace MovieApp.Handlers.Movie.UploadImage
{
    public class MovieUploadImageHandler : IRequestHandler<MovieUploadImageRequest>
    {
        private readonly MovieAppDbContext _context;
        private IFileService _fileService;
        private IUserInfoService _userInfoService;

        public MovieUploadImageHandler(MovieAppDbContext context, IFileService fileService, IUserInfoService userInfoService)
        {
            _context = context;
            _fileService = fileService;
            _userInfoService = userInfoService;
        }
        public async Task Handle(MovieUploadImageRequest request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == request.MovieId);
            if (movie == null)
            {
                throw new BadRequestException($"Фильм {request.MovieId} не найден");
            }

            if (movie.CreatedByUserId != _userInfoService.UserJwtInfoDto?.UserId || !_userInfoService.UserJwtInfoDto.IsAdmin)
            {
                throw new ForbiddenException($"Недостаточно прав");
            }

            var userImagesPath = "/Images/Movies";

            var uploadPathDirectory = $"{Directory.GetCurrentDirectory()}{userImagesPath}";
            var fileExtension = Path.GetExtension(request.File.FileName).ToLowerInvariant();
            var fileName = $"movie_{request.MovieId}{fileExtension}";
            string fullPath = $"{uploadPathDirectory}/{fileName}";

            await _fileService.SaveFile(uploadPathDirectory, fileName, request.File.OpenReadStream());

            movie.ImagePath = fullPath;
            await _context.SaveChangesAsync();
        }
    }
}

