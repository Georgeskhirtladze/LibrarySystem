using LibrarySystem.Domain.Enteties;
using LibrarySystem.Domain.Interfaces;

namespace LibrarySystem.Application.Services;

public class AuthorService
{
    private readonly IAuthorRepository _authorRepo;

    public AuthorService(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }

    public Task<List<Author>> GetAllAsync() => _authorRepo.GetAllAsync();
    public Task<Author?> GetByIdAsync(int id) => _authorRepo.GetByIdAsync(id);
    public Task AddAsync(Author author) => _authorRepo.AddAsync(author);
    public Task UpdateAsync(Author author) => _authorRepo.UpdateAsync(author);
    public Task DeleteAsync(Author author) => _authorRepo.DeleteAsync(author);
}
