using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.DTOs
{

    public class BookReadDto
    {
        public required string Title { get; set; }
        public required string AuthorName { get; set; }
        public required string GenreName { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }

        public int BookAge => DateTime.Now.Year - PublicationYear;
        public bool IsThick => Pages > 100;
    }
}
