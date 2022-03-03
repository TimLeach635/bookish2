using Bookish.Models.Database;

namespace Bookish.Repositories
{
    public class BookRepo
    {
        public List<BookDbModel> GetAllBooks()
        {
            return new List<BookDbModel>
            {
                new BookDbModel
                {
                    Isbn = "0060125632",
                    Title = "The Dispossessed",
                    CoverPhotoUrl = "https://upload.wikimedia.org/wikipedia/en/f/fc/TheDispossed%281stEdHardcover%29.jpg",
                    Blurb = "The Dispossessed (in later printings titled The Dispossessed: An Ambiguous Utopia) is a 1974 utopian science fiction novel by American writer Ursula K. Le Guin, set in the fictional universe of the seven novels of the Hainish Cycle (e.g., The Left Hand of Darkness). It won the Hugo, Locus and Nebula Awards for Best Novel in 1975. It achieved a degree of literary recognition unusual for science fiction due to its exploration of themes such as anarchism (on a satellite planet called Anarres) and revolutionary societies, capitalism, and individualism and collectivism.",
                }
            };
        }
    }
}
