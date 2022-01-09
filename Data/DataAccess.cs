namespace LibraryDbWebApi.Data
{
    public class DataAccess
    {
        LibraryContext libraryDb = new LibraryContext(); 

        public void RecreateDatabase()
        {
            libraryDb.Database.EnsureDeleted();
            libraryDb.Database.EnsureCreated();
        }

        public IEnumerable<Author> GetAuthors()
        {

        }
    }
}
