
namespace LibraryDbWebApi.Data
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
