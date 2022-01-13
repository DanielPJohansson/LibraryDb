namespace LibraryDbWebApi.DTOs
{
    public class GetLibraryBookDTO
    {
        public int LibraryBookId { get; set; }
        public bool IsBorrowed { get; set; }
        public GetBookDTO BookDTO { get; set; }
    }
}
