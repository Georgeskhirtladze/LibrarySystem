using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.DTOs
{
    public class BookCreateDto
    {
        public required string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }
    }
}
