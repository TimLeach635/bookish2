using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public class BookRepo
    {
        private BookishContext context = new BookishContext();

        public List<BookDbModel> GetAllBooks()
        {
            return context
                .Books
                .Include(b => b.Authors)
                .ToList();
        }
    }
}
