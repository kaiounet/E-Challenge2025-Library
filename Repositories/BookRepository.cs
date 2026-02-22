using echal2025library.Models;

namespace echal2025library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books = new();

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book? GetById(Guid id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> SearchByTitle(string title)
        {
            return _books
                .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Book Add(Book book)
        {
            book.Id = Guid.NewGuid();
            _books.Add(book);
            return book;
        }

        public Book? Update(Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.ISBN = book.ISBN;
            existingBook.AvailableCopies = book.AvailableCopies;

            return existingBook;
        }

        public bool Delete(Guid id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return false;
            }

            _books.Remove(book);
            return true;
        }
    }
}
