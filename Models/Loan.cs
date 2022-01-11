using System.ComponentModel.DataAnnotations;

namespace LibraryDbWebApi.Models
{
    public class Loan
    {
        [Key]
        [Required]
        public int LoanId { get; set; }
        public DateTime? LoanDate { get; set; } = DateTime.Today;
        public DateTime? ReturnDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        [Required]
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
