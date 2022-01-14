#nullable disable

namespace LibraryDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryBooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LibraryBooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/LibraryBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLibraryBookDTO>>> GetLibraryBooks()
        {
            var books = await GetLibraryBooksAsDTO()
                .ToListAsync();

            return books;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLibraryBookDTO>> GetLibraryBook(int id)
        {
            var book = await GetLibraryBooksAsDTO().FirstOrDefaultAsync(b => b.LibraryBookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("bytitle/{title}")]
        public async Task<ActionResult<IEnumerable<GetLibraryBookDTO>>> GetBooksByPartialTitle(string title)
        {
            var book = await GetLibraryBooksAsDTO()
                .Where(lb => EF.Functions.Like(lb.BookDTO.Title, $"%{title}%"))
                .OrderBy(lb => lb.BookDTO.Title)
                .ToListAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        private IQueryable<GetLibraryBookDTO> GetLibraryBooksAsDTO()
        {
            return _context.LibraryBooks.Select(lb => new GetLibraryBookDTO()
            {
                LibraryBookId = lb.Id,
                IsBorrowed = lb.IsBorrowed,
                BookDTO = new GetBookDTO()
                {
                    BookId = lb.Book.BookId,
                    Title = lb.Book.Title,
                    Isbn = lb.Book.Isbn,
                    PublicationYear = lb.Book.PublicationYear,
                    ReviewScore = (byte)_context.Reviews.Where(r => r.Book.BookId == lb.Book.BookId).Average(r => r.Score),
                    Authors = lb.Book.Authors.Select(a =>
                    new GetAuthorDTO()
                    {
                        AuthorId = a.AuthorId,
                        FirstName = a.FirstName,
                        LastName = a.LastName
                    })
                .ToList()
                }
            });
        }

        // POST: api/LibraryBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LibraryBook>> PostLibraryBook(PostLibraryBookDTO libraryBookDTO)
        {
            var library = await _context.Libraries.FindAsync(libraryBookDTO.LibraryId);
            var book = await _context.Books.FindAsync(libraryBookDTO.BookId);

            if (library == null || book == null)
            {
                ModelState.AddModelError("InvalidId", "Library or book with submitted IDs does not exist.");
                return BadRequest(ModelState);
            }

            LibraryBook libraryBook = new() { LibraryId = libraryBookDTO.LibraryId, BookId = libraryBookDTO.BookId };

            _context.LibraryBooks.Add(libraryBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibraryBook", new { id = libraryBook.Id }, libraryBook);
        }

        // DELETE: api/LibraryBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryBook(int id)
        {
            var libraryBook = await _context.LibraryBooks.FindAsync(id);
            if (libraryBook == null)
            {
                return NotFound();
            }

            _context.LibraryBooks.Remove(libraryBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
