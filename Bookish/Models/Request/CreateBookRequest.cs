namespace Bookish.Models.Request
{
    public class CreateBookRequest
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? CoverPhotoUrl { get; set; }
        public string? Blurb { get; set; }

        public List<int>? AuthorIds { get; set; }
    }
}
