namespace LibraryDbWebApi.Models
{
    public class Review
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public byte Score { get; set; }
        [Required]
        public Book Book { get; set; }
    }
}
