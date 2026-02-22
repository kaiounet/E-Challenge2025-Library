using echal2025library.DTOs;

namespace echal2025library.Services
{

    public interface IBookService
    {
        List<BookDTO> GetAllBooks();
        BookDTO? GetBookById(Guid id);
        List<BookDTO> SearchBooksByTitle(string title);
        BookDTO AddBook(BookAddDTO bookAddDTO);
        BookDTO? UpdateBook(Guid id, BookUpdateDTO bookUpdateDTO);
        bool DeleteBook(Guid id);
    }
}
