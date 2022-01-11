using System.ComponentModel.DataAnnotations;

namespace LibraryDbWebApi.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
