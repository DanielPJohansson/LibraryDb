
namespace LibraryDbWebApi.Data
{
    public class DataAccess
    {
        public LibraryContext LibraryDb { get; set; }

        public DataAccess(LibraryContext libraryDb)
        {
            LibraryDb = libraryDb;
        }

        public async Task RecreateDatabase()
        {
            LibraryDb.Database.EnsureDeleted();
            await RelationalDatabaseFacadeExtensions.MigrateAsync(LibraryDb.Database);

            Author malcom = new Author() { FirstName = "Malcom", LastName = "Gladwell" };
            Author asne = new Author() { FirstName = "Åsne", LastName = "Seierstad" };
            Author lasse = new Author() { FirstName = "Lasse", LastName = "Berg" };
            Author margaret = new Author() { FirstName = "Margaret", LastName = "Atwood" };
            Author naomi = new Author() { FirstName = "Naomi", LastName = "Klein" };
            Author daniel = new Author() { FirstName = "Daniel", LastName = "Persson" };
            Author ebba = new Author() { FirstName = "Ebba", LastName = "Hanson" };
            Author algot = new Author() { FirstName = "Algot", LastName = "Fanér" };

            Book dogsaw = new Book() { Title = "What the dog saw", Isbn = "9780141047980", PublicationYear = 2010, Authors = new List<Author>() { malcom } };
            Book shock = new Book() { Title = "The shock doctrine", Isbn = "9780141024530", PublicationYear = 2007, Authors = new List<Author>() { naomi } };
            Book kalahari = new Book() { Title = "Gryning över Kalahari", Isbn = "9789170372995", PublicationYear = 2005, Authors = new List<Author>() { lasse } };
            Book groznyj = new Book() { Title = "Ängeln i Groznyj", Isbn = "9789100121945", PublicationYear = 2007, Authors = new List<Author>() { asne } };
            Book assassin = new Book() { Title = "The blind assassin", Isbn = "9780385720953", PublicationYear = 2001, Authors = new List<Author>() { margaret } };
            Book oryx = new Book() { Title = "Oryx and crake", Isbn = " 9780349004068", PublicationYear = 2003, Authors = new List<Author>() { margaret } };
            Book madeup = new Book() { Title = "En kall fisk", Isbn = "9788714045686", PublicationYear = 2018, Authors = new List<Author>() { daniel, ebba, algot } };

            Customer ali = new Customer() { FirstName = "Ali", LastName = "Karkehabadi" };
            Customer anna = new Customer() { FirstName = "Anna", LastName = "Franzén" };
            Customer herman = new Customer() { FirstName = "Elsa", LastName = "Modin" };
            Customer maja = new Customer() { FirstName = "Maja", LastName = "Sonntag" };

            Library library = new Library()
            {
                Name = "Stadsbiblioteket",
                LibraryBooks = new List<LibraryBook>()
                {
                    new LibraryBook() { Book = dogsaw},
                    new LibraryBook() { Book = dogsaw},
                    new LibraryBook() { Book = shock},
                    new LibraryBook() { Book = kalahari},
                    new LibraryBook() { Book = kalahari},
                    new LibraryBook() { Book = groznyj},
                    new LibraryBook() { Book = groznyj},
                    new LibraryBook() { Book = groznyj},
                    new LibraryBook() { Book = assassin},
                    new LibraryBook() { Book = oryx},
                    new LibraryBook() { Book = madeup},
                    new LibraryBook() { Book = madeup},
                    new LibraryBook() { Book = madeup}
                }
            };

            LibraryDb.Authors.Add(malcom);
            LibraryDb.Authors.Add(asne);
            LibraryDb.Authors.Add(lasse);
            LibraryDb.Authors.Add(margaret);
            LibraryDb.Authors.Add(naomi);
            LibraryDb.Authors.Add(daniel);
            LibraryDb.Authors.Add(ebba);
            LibraryDb.Authors.Add(algot);

            LibraryDb.Books.Add(dogsaw);
            LibraryDb.Books.Add(shock);
            LibraryDb.Books.Add(kalahari);
            LibraryDb.Books.Add(groznyj);
            LibraryDb.Books.Add(assassin);
            LibraryDb.Books.Add(oryx);
            LibraryDb.Books.Add(madeup);

            LibraryDb.Customers.Add(ali);
            LibraryDb.Customers.Add(anna);
            LibraryDb.Customers.Add(herman);
            LibraryDb.Customers.Add(maja);

            LibraryDb.Libraries.Add(library);

            await LibraryDb.SaveChangesAsync();
            //await LibraryDb.Database.EnsureCreatedAsync();
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = await LibraryDb.Authors.ToListAsync();
            return authors;
        }
    }
}
