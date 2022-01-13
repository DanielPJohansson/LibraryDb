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

        private IQueryable<GetBookDTO> GetBooksAsDTO()
        {
            return _context.LibraryBooks.Include(b => b.Book).ThenInclude(a => a.Authors)
                            .Select(b => new GetBookDTO()
                            {
                                BookId = b.Id,
                                Title = b.Book.Title,
                                Isbn = b.Book.Isbn,
                                PublicationYear = b.Book.PublicationYear,
                                ReviewScore = b.Book.ReviewScore,
                                IsBorrowed = b.IsBorrowed,
                                Authors = b.Book.Authors.Select(a =>
                                new AuthorDTO()
                                {
                                    AuthorId = a.AuthorId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName
                                })
                                .ToList()
                            });
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookDTO>> GetBook(int id)
        {
            var book = await _context.LibraryBooks.Include(b => b.Book).ThenInclude(_a => _a.Authors)
                .Select(b => new GetBookDTO()
            {
                    BookId = b.Id,
                    Title = b.Book.Title,
                    Isbn = b.Book.Isbn,
                    PublicationYear = b.Book.PublicationYear,
                    ReviewScore = b.Book.ReviewScore,
                    IsBorrowed = b.IsBorrowed,
                    Authors = b.Book.Authors.Select(a =>
                new AuthorDTO()
                {
                    AuthorId = a.AuthorId,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                })
                    .ToList()
            }).FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(PostBookDTO bookDTO)
        {
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
