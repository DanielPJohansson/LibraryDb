namespace LibraryDbWebApi.DTOs
{
    public class PostLibraryBookDTO
    {
        [Required]
        public int LibraryId { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
