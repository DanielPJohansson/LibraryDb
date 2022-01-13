#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryDbWebApi.Data;
using LibraryDbWebApi.Models;

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
                    ReviewScore = lb.Book.ReviewScore,
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

        private bool LibraryBookExists(int id)
        {
            return _context.LibraryBooks.Any(e => e.Id == id);
        }
    }
}
