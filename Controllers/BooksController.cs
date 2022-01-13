#nullable disable

namespace LibraryDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBookDTO>>> GetBooks()
        {
            var books = await GetBooksAsDTO()
                .ToListAsync();

            return books;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookDTO>> GetBook(int id)
        {
            var book = await GetBooksAsDTO().FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        private IQueryable<GetBookDTO> GetBooksAsDTO()
        {
            return _context.Books.Include(a => a.Authors)
                            .Select(b => new GetBookDTO()
                            {
                                BookId = b.BookId,
                                Title = b.Title,
                                Isbn = b.Isbn,
                                PublicationYear = b.PublicationYear,
                                ReviewScore = b.ReviewScore,
                                Authors = b.Authors.Select(a =>
                                new GetAuthorDTO()
                                {
                                    AuthorId = a.AuthorId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName
                                })
                                .ToList()
                            });
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(PostBookDTO bookDTO)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Isbn == bookDTO.Isbn);
            
            if (existingBook != null)
            {
                ModelState.AddModelError("Existing book.", "Book with same ISBN already exists in database.");
                return BadRequest(ModelState);
            }

            Book book = new() { Title = bookDTO.Title, Isbn = bookDTO.Isbn, PublicationYear = bookDTO.PublicationYear };

            foreach (int id in bookDTO.AuthorIds)
            {
                var author = await _context.Authors.FindAsync(id);
                if (author == null)
                {
                    return NotFound();
                }
                book.Authors.Add(author);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
