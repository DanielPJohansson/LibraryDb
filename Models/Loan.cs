using System.ComponentModel.DataAnnotations;

namespace LibraryDbWebApi.Models
{
    public class Loan
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime? LoanDate { get; set; } = DateTime.Today;
        public DateTime? ReturnDate { get; set; }
        [Required]
        public virtual Customer? Borrower { get; set; }
        [Required]
        public virtual Book? Book { get; set; }
    }
}
