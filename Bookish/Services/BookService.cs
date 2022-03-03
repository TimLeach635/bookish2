using Bookish.Repositories;
using Bookish.Models;

namespace Bookish.Services
{
    public class BookService
    {
        private BookRepo _books = new BookRepo();
        private AuthorRepo _authors = new AuthorRepo();
        private AuthorBookRepo _authorBooks = new AuthorBookRepo();

        public List<Book> GetAllBooks()
        {
            var allDbBooks = _books.GetAllBooks();
            var allDbAuthorBooks = _authorBooks.GetAllAuthorBooks();
            var allDbAuthors = _authors.GetAllAuthors();

            List<Book> result = new List<Book>();

            foreach(var dbBook in allDbBooks)
            {
                var dbAuthorBooks = allDbAuthorBooks.FindAll(ab => ab.BookIsbn == dbBook.Isbn);
                var dbAuthors = dbAuthorBooks.Select(ab => allDbAuthors.Find(a => a.Id == ab.AuthorId));

                result.Add(new Book
                {
                    Isbn = dbBook.Isbn,
                    Title = dbBook.Title,
                    CoverPhotoUrl = dbBook.CoverPhotoUrl,
                    Blurb = dbBook.Blurb,
                    Authors = dbAuthors
                        .Select(a => new Author
                        {
                            Name = a.Name,
                        })
                        .ToList(),
                });
            }

            return result;
        }
    }
}
