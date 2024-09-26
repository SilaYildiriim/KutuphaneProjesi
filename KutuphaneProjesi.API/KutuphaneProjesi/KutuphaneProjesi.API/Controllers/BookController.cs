using KutuphaneProjesi.Application.Models.Book;
using KutuphaneProjesi.Application.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneProjesi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddBook([FromForm] AddBookDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _bookService.AddBookAsync(model);
            return Ok(book);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (result)
                return Ok("Book deleted successfully");
            return BadRequest("Failed to delete the book.");
        }

        [Authorize(Roles = "admin")]
        [HttpPatch]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook([FromForm] UpdateBookDto model, Guid id)
        {
            var result = await _bookService.UpdateBookAsync(model, id);
            if (result == null)
                return BadRequest("Failed to update the book. Please check your information and try again.");
            return Ok(result);
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        [Route("GetBooksByTerm/{term}")]
        public async Task<IActionResult> GetBooksByTerm(string term)
        {
            var books = await _bookService.GetBooksByTermAsync(term);
            return Ok(books);
        }
    }
}
