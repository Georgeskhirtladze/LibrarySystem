using LibrarySystem.Domain.Enteties;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Application.Services;

public class GenreService
{
    private readonly IGenreRepository _genreRepo;

    public GenreService(IGenreRepository genreRepo)
    {
        _genreRepo = genreRepo;
    }

    public Task<List<Genre>> GetAllAsync() => _genreRepo.GetAllAsync();
    public Task AddAsync(Genre genre) => _genreRepo.AddAsync(genre);
}
