
namespace LibraryDbWebApi.Data
{
    public class DatabaseInitializer
    {
        public LibraryContext LibraryDb { get; set; }

        public DatabaseInitializer()
        {
            LibraryDb = new LibraryContext();
        }

        public DatabaseInitializer(LibraryContext libraryDb)
        {
            LibraryDb = libraryDb;
        }

        public async Task RecreateDatabase()
        {
            LibraryDb.Database.EnsureDeleted();
            await RelationalDatabaseFacadeExtensions.MigrateAsync(LibraryDb.Database);

            await SeedDatabase();
        }

        private async Task SeedDatabase()
        {
            Author malcom = new Author() { FirstName = "Malcom", LastName = "Gladwell" };
            Author asne = new Author() { FirstName = "Åsne", LastName = "Seierstad" };
            Author lasse = new Author() { FirstName = "Lasse", LastName = "Berg" };
            Author margaret = new Author() { FirstName = "Margaret", LastName = "Atwood" };
            Author naomi = new Author() { FirstName = "Naomi", LastName = "Klein" };
            Author daniel = new Author() { FirstName = "Daniel", LastName = "Persson" };
            Author ebba = new Author() { FirstName = "Ebba", LastName = "Hanson" };
            Author algot = new Author() { FirstName = "Algot", LastName = "Fanér" };
            Author arvid = new Author() { FirstName = "Arvid", LastName = "Pamlur" };
            Author orhan = new Author() { FirstName = "Orhan", LastName = "Pamuk" };
            Author signe = new Author() { FirstName = "Signe", LastName = "Klason" };
            Author irma = new Author() { FirstName = "Irma", LastName = "Berggren" };

            Book dogsaw = new Book() { Title = "What the dog saw", Isbn = "9780141047980", PublicationYear = 2010, Authors = new List<Author>() { malcom } };
            Book shock = new Book() { Title = "The shock doctrine", Isbn = "9780141024530", PublicationYear = 2007, Authors = new List<Author>() { naomi } };
            Book kalahari = new Book() { Title = "Gryning över Kalahari", Isbn = "9789170372995", PublicationYear = 2005, Authors = new List<Author>() { lasse } };
            Book groznyj = new Book() { Title = "Ängeln i Groznyj", Isbn = "9789100121945", PublicationYear = 2007, Authors = new List<Author>() { asne } };
            Book assassin = new Book() { Title = "The blind assassin", Isbn = "9780385720953", PublicationYear = 2001, Authors = new List<Author>() { margaret } };
            Book oryx = new Book() { Title = "Oryx and crake", Isbn = " 9780349004068", PublicationYear = 2003,  Authors = new List<Author>() { margaret } };
            Book madeup = new Book() { Title = "En kall fisk", Isbn = "9788714045686", PublicationYear = 2018, Authors = new List<Author>() { daniel, ebba, algot } };

            Review review01 = new Review() { Score = 85, Book = dogsaw };
            Review review02 = new Review() { Score = 79, Book = dogsaw };
            Review review03 = new Review() { Score = 69, Book = dogsaw };
            Review review04 = new Review() { Score = 76, Book = shock };
            Review review05 = new Review() { Score = 85, Book = shock };
            Review review06 = new Review() { Score = 78, Book = kalahari };
            Review review07 = new Review() { Score = 56, Book = groznyj };
            Review review08 = new Review() { Score = 76, Book = assassin };
            Review review09 = new Review() { Score = 86, Book = assassin };
            Review review10 = new Review() { Score = 65, Book = oryx };
            Review review11 = new Review() { Score = 98, Book = madeup };
            Review review12 = new Review() { Score = 99, Book = madeup };

            Customer ali = new Customer() { FirstName = "Ali", LastName = "Karkehabadi", LoanCardNumber = 400786360 };
            Customer anna = new Customer() { FirstName = "Anna", LastName = "Franzén", LoanCardNumber = 302800247 };
            Customer herman = new Customer() { FirstName = "Elsa", LastName = "Modin", LoanCardNumber = 900432540 };
            Customer maja = new Customer() { FirstName = "Maja", LastName = "Sonntag", LoanCardNumber = 400278036 };

            Library library = new Library() { Name = "Stadsbiblioteket" };

            LibraryBook book01 = new LibraryBook() { Book = dogsaw, Library = library, IsBorrowed = true };
            LibraryBook book02 = new LibraryBook() { Book = dogsaw, Library = library };
            LibraryBook book03 = new LibraryBook() { Book = shock, Library = library, IsBorrowed = true };
            LibraryBook book04 = new LibraryBook() { Book = kalahari, Library = library };
            LibraryBook book05 = new LibraryBook() { Book = kalahari, Library = library, IsBorrowed = true };
            LibraryBook book06 = new LibraryBook() { Book = groznyj, Library = library };
            LibraryBook book07 = new LibraryBook() { Book = groznyj, Library = library };
            LibraryBook book08 = new LibraryBook() { Book = groznyj, Library = library };
            LibraryBook book09 = new LibraryBook() { Book = assassin, Library = library };
            LibraryBook book10 = new LibraryBook() { Book = oryx, Library = library, IsBorrowed = true };
            LibraryBook book11 = new LibraryBook() { Book = madeup, Library = library };
            LibraryBook book12 = new LibraryBook() { Book = madeup, Library = library };
            LibraryBook book13 = new LibraryBook() { Book = madeup, Library = library };

            Loan loan01 = new Loan() { Customer = herman, LibraryBook = book01, LoanDate = new DateTime(2022, 01, 10) };
            Loan loan02 = new Loan() { Customer = ali, LibraryBook = book10, LoanDate = new DateTime(2021, 12, 27) };
            Loan loan03 = new Loan() { Customer = herman, LibraryBook = book03, LoanDate = new DateTime(2022, 01, 12) };
            Loan loan04 = new Loan() { Customer = herman, LibraryBook = book05, LoanDate = new DateTime(2021, 11, 20) };

            LibraryDb.Authors.Add(malcom);
            LibraryDb.Authors.Add(asne);
            LibraryDb.Authors.Add(lasse);
            LibraryDb.Authors.Add(margaret);
            LibraryDb.Authors.Add(naomi);
            LibraryDb.Authors.Add(daniel);
            LibraryDb.Authors.Add(ebba);
            LibraryDb.Authors.Add(algot);
            LibraryDb.Authors.Add(arvid);
            LibraryDb.Authors.Add(orhan);
            LibraryDb.Authors.Add(signe);
            LibraryDb.Authors.Add(irma);

            LibraryDb.Books.Add(dogsaw);
            LibraryDb.Books.Add(shock);
            LibraryDb.Books.Add(kalahari);
            LibraryDb.Books.Add(groznyj);
            LibraryDb.Books.Add(assassin);
            LibraryDb.Books.Add(oryx);
            LibraryDb.Books.Add(madeup);

            LibraryDb.Reviews.Add(review01);
            LibraryDb.Reviews.Add(review02);
            LibraryDb.Reviews.Add(review03);
            LibraryDb.Reviews.Add(review04);
            LibraryDb.Reviews.Add(review05);
            LibraryDb.Reviews.Add(review06);
            LibraryDb.Reviews.Add(review07);
            LibraryDb.Reviews.Add(review08);
            LibraryDb.Reviews.Add(review09);
            LibraryDb.Reviews.Add(review10);
            LibraryDb.Reviews.Add(review11);
            LibraryDb.Reviews.Add(review12);

            LibraryDb.Customers.Add(ali);
            LibraryDb.Customers.Add(anna);
            LibraryDb.Customers.Add(herman);
            LibraryDb.Customers.Add(maja);

            LibraryDb.LibraryBooks.Add(book01);
            LibraryDb.LibraryBooks.Add(book02);
            LibraryDb.LibraryBooks.Add(book03);
            LibraryDb.LibraryBooks.Add(book04);
            LibraryDb.LibraryBooks.Add(book05);
            LibraryDb.LibraryBooks.Add(book06);
            LibraryDb.LibraryBooks.Add(book07);
            LibraryDb.LibraryBooks.Add(book08);
            LibraryDb.LibraryBooks.Add(book09);
            LibraryDb.LibraryBooks.Add(book10);
            LibraryDb.LibraryBooks.Add(book11);
            LibraryDb.LibraryBooks.Add(book12);
            LibraryDb.LibraryBooks.Add(book13);

            LibraryDb.Loans.Add(loan01);
            LibraryDb.Loans.Add(loan02);
            LibraryDb.Loans.Add(loan03);
            LibraryDb.Loans.Add(loan04);

            LibraryDb.Libraries.Add(library);

            await LibraryDb.SaveChangesAsync();
        }
    }
}
