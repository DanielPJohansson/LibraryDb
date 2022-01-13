namespace LibraryDbWebApi.Data
{
    public class GetBookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int PublicationYear { get; set; }
        public bool IsBorrowed { get; set; }
        public byte? ReviewScore { get; set; }
        public List<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();

    }
}
