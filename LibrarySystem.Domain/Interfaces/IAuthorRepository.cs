﻿using LibrarySystem.Domain.Enteties;

namespace LibrarySystem.Domain.Interfaces;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAsync();
    Task<Author?> GetByIdAsync(int id);
    Task AddAsync(Author author);
    Task UpdateAsync(Author author);
    Task DeleteAsync(Author author);
}