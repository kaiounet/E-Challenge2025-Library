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
        // [ProducesResponseType(typeof(List<BookDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        // [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        // [ProducesResponseType(typeof(List<BookDTO>), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        // [ProducesResponseType(typeof(BookDTO), StatusCodes.Status201Created)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        // [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
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
