using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Entities;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.Files;
using static System.Net.Mime.MediaTypeNames;

namespace MovieApp.Handlers.Actors.UploadImage
{
    public class ActorUploadImageHandler : IRequestHandler<ActorUploadImageRequest>
    {
        private readonly MovieAppDbContext _context;
        private IFileService _fileService;

        public ActorUploadImageHandler(MovieAppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }
        public async Task Handle(ActorUploadImageRequest request, CancellationToken cancellationToken)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == request.ActorId);
            if (actor == null)
            {
                throw new BadRequestException($"Актер {request.ActorId} не найден");
            }

            var userImagesPath = "/Images/Acrots";

            var uploadPathDirectory = $"{Directory.GetCurrentDirectory()}{userImagesPath}";
            var fileExtension = Path.GetExtension(request.File.FileName).ToLowerInvariant();
            var fileName = $"actor_{request.ActorId}{fileExtension}";
            string fullPath = $"{uploadPathDirectory}/{fileName}";

            await _fileService.SaveFile(uploadPathDirectory, fileName, request.File.OpenReadStream());

            actor.ImagePath = fullPath;
            await _context.SaveChangesAsync();
        }
    }
}

