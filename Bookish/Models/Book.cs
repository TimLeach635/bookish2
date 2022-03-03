namespace Bookish.Models
{
    public class Book
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public List<Author>? Authors { get; set; }
        public string? CoverPhotoUrl { get; set; }
        public string? Blurb { get; set; }
    }
}
