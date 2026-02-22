using echal2025library.DTOs;
using echal2025library.Services;
using Microsoft.AspNetCore.Mvc;

namespace echal2025library.Controllers
{
    [Route("library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookService _bookService;

        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound(new { message = $"Book with ID {id} not found." });
            }
            return Ok(book);
        }

        [HttpGet("search")]
        public IActionResult SearchBooksByTitle([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest(new { message = "Title query parameter is required." });
            }

            var books = _bookService.SearchBooksByTitle(title);
            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookAddDTO bookAddDTO)
        {
            if (bookAddDTO == null)
            {
                return BadRequest(new { message = "Book data is required." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBook = _bookService.AddBook(bookAddDTO);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBook(Guid id, [FromBody] BookUpdateDTO bookUpdateDTO)
        {
            if (bookUpdateDTO == null)
            {
                return BadRequest(new { message = "Book data is required." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedBook = _bookService.UpdateBook(id, bookUpdateDTO);
            if (updatedBook == null)
            {
                return NotFound(new { message = $"Book with ID {id} not found." });
            }

            return Ok(updatedBook);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBook(Guid id)
        {
            var deleted = _bookService.DeleteBook(id);
            if (!deleted)
            {
                return NotFound(new { message = $"Book with ID {id} not found." });
            }

            return NoContent();
        }
    }
}
