﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Enteties
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }

        

    }
}
