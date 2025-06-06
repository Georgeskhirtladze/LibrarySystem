using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Enteties;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Pages { get; set; }
    public int PublicationYear { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
}
