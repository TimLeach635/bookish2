using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public class AuthorRepo
    {
        public List<AuthorDbModel> GetAllAuthors()
        {
            return new List<AuthorDbModel>
            {
                new AuthorDbModel
                {
                    Id = 1,
                    Name = "Ursula K. Le Guin",
                }
            };
        }
    }
}
