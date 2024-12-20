using System;
using System.Collections.Generic;
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
        //public List<Author> Authors { get; set; } = new();

        //public int AuthorId;
        //public Author Author { get; set; } = new();
    }
}
