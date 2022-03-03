using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public class AuthorBookRepo
    {
        public List<AuthorBookDbModel> GetAllAuthorBooks()
        {
            return new List<AuthorBookDbModel>
            {
                new AuthorBookDbModel
                {
                    Id = 1,
                    AuthorId = 1,
                    BookIsbn = "0060125632",
                }
            };
        }
    }
}
