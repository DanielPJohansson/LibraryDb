namespace LibraryDbWebApi.DTOs
{
    public class PostCustomerDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
