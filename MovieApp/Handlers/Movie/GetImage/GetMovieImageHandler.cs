using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.Files;

namespace MovieApp.Handlers.Movie.GetImage;

public class GetMovieImageHandler : IRequestHandler<GetMovieImageRequest, byte[]>
{
    private readonly MovieAppDbContext _context;
    private readonly IFileService _fileService;

    public GetMovieImageHandler(MovieAppDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<byte[]> Handle(GetMovieImageRequest request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.MovieId);

        if (movie == null)
        {
            throw new NotFoundException($"Фильм {request.MovieId} не найден");
        }

        if (movie.ImagePath == null || !File.Exists(movie.ImagePath))
        {
            throw new NotFoundException($"У фильма {request.MovieId} нет фотографии");
        }

        return await _fileService.GetFile(movie.ImagePath);
    }
}
