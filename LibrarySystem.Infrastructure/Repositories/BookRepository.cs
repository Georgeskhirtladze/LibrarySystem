using LibrarySystem.Domain.Interfaces;
using LibrarySystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Domain.Enteties;
using LibrarySystem.Application.DTOs; // <-- Add this

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<Book> Items, int TotalCount)> GetFilteredAsync(BookFilterDto filter)
        {
            var query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .AsQueryable();

            if (filter.MinPages.HasValue)
                query = query.Where(b => b.Pages >= filter.MinPages.Value);

            if (filter.MaxPages.HasValue)
                query = query.Where(b => b.Pages <= filter.MaxPages.Value);

            if (filter.AuthorId.HasValue)
                query = query.Where(b => b.AuthorId == filter.AuthorId.Value);

            if (filter.GenreId.HasValue)
                query = query.Where(b => b.GenreId == filter.GenreId.Value);


            query = filter.SortBy!.ToLower() switch
            {
                "pages" => filter.SortDirection == "desc"
                    ? query.OrderByDescending(b => b.Pages)
                    : query.OrderBy(b => b.Pages),

                "publicationyear" => filter.SortDirection == "desc"
                    ? query.OrderByDescending(b => b.PublicationYear)
                    : query.OrderBy(b => b.PublicationYear),

                _ => filter.SortDirection == "desc"
                    ? query.OrderByDescending(b => b.Title)
                    : query.OrderBy(b => b.Title)
            };

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
