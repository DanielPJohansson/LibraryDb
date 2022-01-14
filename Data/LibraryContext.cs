
namespace LibraryDbWebApi.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryBook> LibraryBooks { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public LibraryContext()
        {

        }

        public LibraryContext(DbContextOptions<LibraryContext> contextOptions) : base(contextOptions)
        {

        }
    }
}
