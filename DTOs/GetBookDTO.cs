namespace LibraryDbWebApi.DTOs
{
    public class GetBookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int PublicationYear { get; set; }
        public byte? ReviewScore { get; set; }
        public List<GetAuthorDTO> Authors { get; set; } = new List<GetAuthorDTO>();

    }
}
