using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
