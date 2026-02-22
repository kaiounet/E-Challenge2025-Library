using echal2025library.Models;

namespace echal2025library.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? GetById(Guid id);
        List<Book> SearchByTitle(string title);
        Book Add(Book book);
        Book? Update(Book book);
        bool Delete(Guid id);
    }
}
