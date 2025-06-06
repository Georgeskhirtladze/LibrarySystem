using LibrarySystem.Domain.Enteties;
using LibrarySystem.Domain.Interfaces;
using LibrarySystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly LibraryDbContext _context;

    public GenreRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Genre>> GetAllAsync() => await _context.Genres.ToListAsync();

    public async Task<Genre?> GetByIdAsync(int id) => await _context.Genres.FindAsync(id);

    public async Task AddAsync(Genre genre)
    {
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();
    }
}
