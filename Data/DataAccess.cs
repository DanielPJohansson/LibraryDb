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

        public async Task RecreateDatabase()
        {
            LibraryDb.Database.EnsureDeleted();
            LibraryDb.Database.EnsureCreated();


        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = await LibraryDb.Authors.ToListAsync();
            return authors;
        }
    }
}
