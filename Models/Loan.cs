
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
        public virtual Customer? Customer { get; set; }
        [Required]
        public virtual LibraryBook? Book { get; set; }
    }
}
