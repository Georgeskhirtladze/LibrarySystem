using LibrarySystem.Domain.Enteties;

namespace LibrarySystem.Domain.Interfaces;

public interface IGenreRepository
{
    Task<List<Genre>> GetAllAsync();
    Task<Genre?> GetByIdAsync(int id);
    Task AddAsync(Genre genre);
}
