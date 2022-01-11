using System.ComponentModel.DataAnnotations;

namespace LibraryDbWebApi.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Isbn { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public bool IsBorrowed { get; set; }
        public byte? ReviewScore { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
