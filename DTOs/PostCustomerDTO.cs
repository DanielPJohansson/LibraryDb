namespace LibraryDbWebApi.DTOs
{
    public class PostCustomerDTO
    {
        [Required]
        public int LoanCardNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
