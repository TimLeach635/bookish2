using Bookish.Repositories;
using Bookish.Models;

namespace Bookish.Services
{
    public class BookService
    {
        private BookRepo _books = new BookRepo();
        private AuthorRepo _authors = new AuthorRepo();

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
