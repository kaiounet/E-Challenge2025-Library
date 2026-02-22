using echal2025library.DTOs;
using echal2025library.Mappers;
using echal2025library.Models;
using echal2025library.Repositories;

namespace echal2025library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookDTO> GetAllBooks()
        {
            var books = _bookRepository.GetAll();
            return books.ToDTOs().ToList();
        }

        public BookDTO? GetBookById(Guid id)
        {
            var book = _bookRepository.GetById(id);
            return book?.ToDTO();
        }

        public List<BookDTO> SearchBooksByTitle(string title)
        {
            var books = _bookRepository.SearchByTitle(title);
            return books.ToDTOs().ToList();
        }

        public BookDTO AddBook(BookAddDTO bookAddDTO)
        {
            var book = bookAddDTO.ToModel();
            var addedBook = _bookRepository.Add(book);
            return addedBook.ToDTO();
        }

        public BookDTO? UpdateBook(Guid id, BookUpdateDTO bookUpdateDTO)
        {
            var existingBook = _bookRepository.GetById(id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.UpdateFrom(bookUpdateDTO);
            var updatedBook = _bookRepository.Update(existingBook);
            return updatedBook?.ToDTO();
        }

        public bool DeleteBook(Guid id)
        {
            return _bookRepository.Delete(id);
        }
    }
}
