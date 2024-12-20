using AutoMapper;
using LibraryDAL.Entities;
using LibraryDAL.Services;
using LibraryServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookPreviewModel>> BooksPreview()
        {
            var books = await _bookRepository.GetAll();
            var bookPreviewModels = _mapper.Map<List<BookPreviewModel>>(books);
            return bookPreviewModels;
        }

        public async Task<BookViewModel> BookView(int id)
        {
            if (id < 1)
            {
                throw new NullReferenceException();
            }
            var book = await _bookRepository.Get(id);
            var bookView = _mapper.Map<BookViewModel>(book);
            return bookView;
        }

        public async Task AddNewBook(BookViewModel bookViewModel)
        {
            if (bookViewModel?.Title == null || bookViewModel?.Author == null) 
            {
                throw new NullReferenceException();
            }
            var book = _mapper.Map<Book>(bookViewModel);
            await _bookRepository.Add(book);
        }

        public async Task DeleteBook(int id)
        {
            if (id < 1)
            {
                throw new NullReferenceException();
            }
            await _bookRepository.Delete(id);
        }

        public async Task UpdateBook(BookViewModel bookViewModel)
        {
            if (bookViewModel?.Title == null || bookViewModel?.Author == null)
            {
                throw new NullReferenceException();
            }
            var book = _mapper.Map<Book>(bookViewModel);
            await _bookRepository.Update(book);
        }
    }
}
