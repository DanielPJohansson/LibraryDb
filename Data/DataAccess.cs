using LibraryDbWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryDbWebApi.Data
{
    public class DataAccess
    {
        public LibraryContext LibraryDb { get; set; }

        public DataAccess(LibraryContext libraryDb)
        {
            LibraryDb = libraryDb;
        }

        public void RecreateDatabase()
        {
            LibraryDb.Database.EnsureDeleted();
            LibraryDb.Database.EnsureCreated();
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            IEnumerable<Author> authors = await LibraryDb.Authors.ToListAsync();
            return authors;
        }
    }
}
