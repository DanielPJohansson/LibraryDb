
namespace LibraryDbWebApi.Data
{
    public class PostBookDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
        [Required]
        public byte? ReviewScore { get; set; }
        [Required]
        public List<int> AuthorIds { get; set; }
    }
}
