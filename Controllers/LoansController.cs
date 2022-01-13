#nullable disable

namespace LibraryDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoans()
        {
            var loans = await GetLoanAsDTO()
                .ToListAsync();

            return loans;
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDTO>> GetLoan(int id)
        {
            var loan = await GetLoanAsDTO().FirstOrDefaultAsync(b => b.LoanId == id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        private IQueryable<LoanDTO> GetLoanAsDTO()
        {
            return _context.Loans.Select(l => new LoanDTO()
            {
                LoanId = l.LoanId,
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate,
                LibraryBookId = l.LibraryBookId,
                CustomerId = l.CustomerId,
                Customer = l.Customer
            });
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBook(int id, Book book)
        //{
        //    if (id != book.BookId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
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

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostLoan(int customerId, int libraryBookId)
        {
            var libraryBook = await _context.LibraryBooks.FindAsync(libraryBookId);

            if (libraryBook.IsBorrowed)
            {
                return BadRequest();
            }

            Loan loan = new Loan() { CustomerId = customerId, LibraryBookId = libraryBookId };
            libraryBook.IsBorrowed= true;
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.LoanId }, loan);
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.LoanId == id);
        }
    }
}
