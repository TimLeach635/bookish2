using Microsoft.EntityFrameworkCore;
using Bookish.Models.Database;

namespace Bookish
{
    public class BookishContext : DbContext
    {
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<BookDbModel> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Bookish;Trusted_Connection=True;");
        }
    }
}
