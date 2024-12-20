using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int IssueYear { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = new();

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = new();

    }
}
