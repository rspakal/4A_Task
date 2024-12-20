using LibraryDAL.Entities;
using LibraryDAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookService;
        public BookController(IBookRepository bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAll();
            return View(books);
        }

        [HttpGet("book/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("book/create")]
        public async Task<IActionResult> Create([FromBody]Book book)
        {
            await _bookService.Add(book);
            return View("Index", "Book");
        }

        [HttpGet("book/delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _bookService.Delete(id);
            return View("Index", "Book");
        }

        [HttpGet("book/update")]
        public async Task<IActionResult> Update([FromQuery] int id)
        {
            var book = await _bookService.Get(id);
            return View(book);
        }

        [HttpPost("book/update")]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            await _bookService.Update(book);
            return View("Index", "Book");
        }
    }
}
