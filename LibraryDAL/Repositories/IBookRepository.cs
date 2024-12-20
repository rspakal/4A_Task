using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Services
{
    public interface IBookRepository
    {
        public Task Add(Book book);
        public Task Delete(int id);
        public Task<Book> Get(int id);
        public Task<IEnumerable<Book>> GetAll();
        public Task Update(Book book);
    }
}
