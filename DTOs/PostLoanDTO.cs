namespace LibraryDbWebApi.DTOs
{
    public class PostLoanDTO
    {
        [Required]
        public int LibraryBookId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
