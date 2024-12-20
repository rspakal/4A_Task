using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Models
{
    public class BookViewModel : BookModelBase
    {
        public List<Chapter> Content = new();

        public class Chapter
        {
            public int Number { get; set; }
            public string Title { get; set; } = string.Empty;
            public int Page { get; set; }
        }
    }
}
