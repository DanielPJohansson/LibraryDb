
namespace LibraryDbWebApi
{
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int LoanCardNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

    }
}
