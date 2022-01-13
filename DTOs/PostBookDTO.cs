
namespace LibraryDbWebApi.DTOs
{
    public class PostBookDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [IsbnValidation]
        public string Isbn { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public byte? ReviewScore { get; set; }
        [Required]
        public List<int> AuthorIds { get; set; }
    }
}
