using Bookish.Repositories;
using Bookish.Models;

namespace Bookish.Services
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
    }

    public class BookService : IBookService
    {
        private IBookRepo _books;

        public BookService(IBookRepo books)
        {
            _books = books;
        }

        public List<Book> GetAllBooks()
        {
            var allDbBooks = _books.GetAllBooks();

            List<Book> result = new List<Book>();

            foreach (var dbBook in allDbBooks)
            {
                result.Add(new Book
                {
                    Isbn = dbBook.Isbn,
                    Title = dbBook.Title,
                    Blurb = dbBook.Blurb,
                    CoverPhotoUrl = dbBook.CoverPhotoUrl,
                    Authors = dbBook
                        .Authors
                        .Select(a => new Author
                            {
                                Name = a.Name,
                                AuthorPhotoUrl = a.AuthorPhotoUrl
                            })
                        .ToList(),
                });
            }

            return result;
        }
    }
}
