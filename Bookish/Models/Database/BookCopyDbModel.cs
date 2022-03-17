using System.ComponentModel.DataAnnotations;

namespace Bookish.Models.Database
{
    public class BookCopyDbModel
    {
        public BookDbModel Book { get; set; }

        public List<OrderDbModel> Orders { get; set; }
    }
}
