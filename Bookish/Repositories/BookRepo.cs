using Bookish.Models.Database;
using Bookish.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IBookRepo
    {
        public List<BookDbModel> GetAllBooks();
        public BookDbModel CreateBook(CreateBookRequest createBookRequest);
    }

    public class BookRepo : IBookRepo
    {
        private BookishContext context = new BookishContext();

        public List<BookDbModel> GetAllBooks()
        {
            return context
                .Books
                .Include(b => b.Authors)
                .ToList();
        }

        public BookDbModel CreateBook(CreateBookRequest createBookRequest)
        {
            var newBook = new BookDbModel
            {
                Isbn = createBookRequest.Isbn,
                Title = createBookRequest.Title,
                CoverPhotoUrl = createBookRequest.CoverPhotoUrl,
                Blurb = createBookRequest.Blurb,
            };

            var insertedBook = context.Books.Add(newBook).Entity;

            if (createBookRequest.AuthorIds != null)
            {
                insertedBook.Authors = new List<AuthorDbModel>();

                foreach (int authorId in createBookRequest.AuthorIds)
                {
                    insertedBook.Authors.Add(
                        context.Authors.Where(a => a.Id == authorId).Single()
                    );
                }
            }

            context.SaveChanges();

            return insertedBook;
        }
    }
}
