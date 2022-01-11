using System.ComponentModel.DataAnnotations;

namespace LibraryDbWebApi
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int LoanCardNumber { get; set; } = new Random().Next(1, 1000);
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

    }
}
