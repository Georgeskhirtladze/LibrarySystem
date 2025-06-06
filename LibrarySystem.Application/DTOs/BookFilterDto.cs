using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.DTOs
{
    public class BookFilterDto
    {
        public int? MinPages { get; set; }
        public int? MaxPages { get; set; }
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
        public string? SortBy { get; set; } = "Title";
        public string? SortDirection { get; set; } = "asc";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
