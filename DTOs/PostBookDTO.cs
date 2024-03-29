﻿
namespace LibraryDbWebApi.DTOs
{
    public class PostBookDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        private string _isbn;
        [Required]
        [IsbnValidation]
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                _isbn = new string(value.Trim().Replace("-",""));
            }
        }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public List<int> AuthorIds { get; set; }
    }
}
