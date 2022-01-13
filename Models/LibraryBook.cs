namespace LibraryDbWebApi.Models
{
    public class LibraryBook
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public bool IsBorrowed { get; set; } = false;
    }
}
