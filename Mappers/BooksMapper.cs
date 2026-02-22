using echal2025library.DTOs;
using echal2025library.Models;

namespace echal2025library.Mappers
{
    public static class BooksMapper
    {
        public static BookDTO ToDTO(this Book book)
        {
            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN,
                AvailableCopies = book.AvailableCopies
            };
        }
        public static IEnumerable<BookDTO> ToDTOs(this IEnumerable<Book> books)
        {
            return books.Select(b => b.ToDTO());
        }
        public static Book ToModel(this BookAddDTO bookAddDTO)
        {
            return new Book
            {
                Title = bookAddDTO.Title,
                Author = bookAddDTO.Author,
                PublicationYear = bookAddDTO.PublicationYear,
                ISBN = bookAddDTO.ISBN,
                AvailableCopies = bookAddDTO.AvailableCopies
            };
        }
        public static Book ToModel(this BookUpdateDTO bookUpdateDTO)
        {
            return new Book
            {
                Title = bookUpdateDTO.Title,
                Author = bookUpdateDTO.Author,
                PublicationYear = bookUpdateDTO.PublicationYear,
                ISBN = bookUpdateDTO.ISBN,
                AvailableCopies = bookUpdateDTO.AvailableCopies
            };
        }
        public static Book UpdateFrom(this Book book, BookUpdateDTO bookUpdateDTO)
        {
            book.Title = bookUpdateDTO.Title;
            book.Author = bookUpdateDTO.Author;
            book.PublicationYear = bookUpdateDTO.PublicationYear;
            book.ISBN = bookUpdateDTO.ISBN;
            book.AvailableCopies = bookUpdateDTO.AvailableCopies;
            return book;
        }
    }
}
