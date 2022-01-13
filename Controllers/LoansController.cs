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
        public async Task<ActionResult<IEnumerable<GetLoanDTO>>> GetLoans()
        {
            var loans = await GetLoanAsDTO()
                .ToListAsync();

            return loans;
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLoanDTO>> GetLoan(int id)
        {
            var loan = await GetLoanAsDTO().FirstOrDefaultAsync(b => b.LoanId == id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        private IQueryable<GetLoanDTO> GetLoanAsDTO()
        {
            return _context.Loans.Select(l => new GetLoanDTO()
            {
                LoanId = l.LoanId,
                LoanDate = l.LoanDate,
                ReturnDate = l.ReturnDate,
                LibraryBookId = l.LibraryBookId,
                Book = new GetBookDTO() { BookId = l.LibraryBook.Book.BookId, Title = l.LibraryBook.Book.Title },
                CustomerId = l.CustomerId,
                Customer = l.Customer
            });
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> ReturnOfLoan(int id)
        {
            var loan = await _context.Loans.Include(l => l.LibraryBook).FirstOrDefaultAsync(l => l.LoanId == id);

            if (loan == null || loan.ReturnDate != null)
            {
                ModelState.AddModelError("Loan", "Loan does not exist or book has been returned.");
                return BadRequest(ModelState);
            }

            loan.ReturnDate = DateTime.Now;
            loan.LibraryBook.IsBorrowed = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
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

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(PostLoanDTO loanDTO)
        {
            var libraryBook = await _context.LibraryBooks.FindAsync(loanDTO.LibraryBookId);

            if (libraryBook == null)
            {
                return NotFound();
            }

            if (libraryBook.IsBorrowed)
            {
                return BadRequest();
            }

            Loan loan = new Loan() { CustomerId = loanDTO.CustomerId, LibraryBookId = loanDTO.LibraryBookId };
            libraryBook.IsBorrowed = true;
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
