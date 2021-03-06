using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IAuthorRepo
    {
        public List<AuthorDbModel> GetAllAuthors();
        public AuthorDbModel GetById(int id);
        public AuthorDbModel CreateAuthor(AuthorDbModel newAuthor);
    }

    public class AuthorRepo : IAuthorRepo
    {
        private BookishContext context = new BookishContext();

        public List<AuthorDbModel> GetAllAuthors()
        {
            return context
                .Authors
                .Include(a => a.Books)
                .ToList();
        }

        public AuthorDbModel GetById(int id)
        {
            return context
                .Authors
                .Where(a => a.Id == id)
                .Single();
        }

        public AuthorDbModel CreateAuthor(AuthorDbModel newAuthor)
        {
            // explicitly remove ID, as you're not allowed to specify it
            var authorNoId = new AuthorDbModel
            {
                Name = newAuthor.Name,
                AuthorPhotoUrl = newAuthor.AuthorPhotoUrl,
            };

            var insertedAuthorEntry = context.Authors.Add(authorNoId);
            context.SaveChanges();

            return insertedAuthorEntry.Entity;
        }
    }
}
