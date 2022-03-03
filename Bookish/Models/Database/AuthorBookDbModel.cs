namespace Bookish.Models.Database
{
    public class AuthorBookDbModel
    {
        public int? Id { get; set; }
        public int? AuthorId { get; set; }
        public string? BookIsbn { get; set; }
    }
}
