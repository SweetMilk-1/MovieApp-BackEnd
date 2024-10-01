using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.Files;

namespace MovieApp.Handlers.Actors.GetImage;

public class GetActorImageHandler : IRequestHandler<GetActorImageRequest, byte[]>
{
    private readonly MovieAppDbContext _context;
    private readonly IFileService _fileService;

    public GetActorImageHandler(MovieAppDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<byte[]> Handle(GetActorImageRequest request, CancellationToken cancellationToken)
    {
        var actor = await _context.Actors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.ActorId);

        if (actor == null)
        {
            throw new NotFoundException($"Актер {request.ActorId} не найден");
        }

        if (actor.ImagePath == null || !File.Exists(actor.ImagePath))
        {
            throw new NotFoundException($"У актера {request.ActorId} нет фотографии");
        }

        return await _fileService.GetFile(actor.ImagePath);
    }
}
