#nullable disable

namespace LibraryDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAuthorDTO>>> GetAuthors()
        {
            var authors = await GetAuthorAsDTO().ToListAsync();

            return authors;
        }

        //// GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorDTO>> GetAuthor(int id)
        {
            var author = await GetAuthorAsDTO().FirstOrDefaultAsync(a => a.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpGet("bylastname/{lastName}")]
        public async Task<ActionResult<IEnumerable<GetAuthorDTO>>> GetAuthorsByFirstName(string lastName)
        {
            var author = await GetAuthorAsDTO().Where(a => a.LastName == lastName).ToListAsync();

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        private IQueryable<GetAuthorDTO> GetAuthorAsDTO()
        {
            return _context.Authors.Select(a => new GetAuthorDTO()
            {
                AuthorId = a.AuthorId,
                FirstName = a.FirstName,
                LastName = a.LastName

            });
        }


        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAuthor(int id, Author author)
        //{
        //    if (id != author.AuthorId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(author).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(PostAuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                FirstName = authorDTO.FirstName,
                LastName= authorDTO.LastName
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
