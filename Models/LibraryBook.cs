namespace LibraryDbWebApi.Models
{
    public class LibraryBook
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public Library Library { get; set; }
        public bool IsBorrowed { get; set; } = false;
    }
}
