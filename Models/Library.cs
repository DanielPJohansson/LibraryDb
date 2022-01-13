namespace LibraryDbWebApi.Models
{
    public class Library
    {
        [Key]
        [Required]
        public int LibraryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();
    }
}
