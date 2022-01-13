namespace LibraryDbWebApi.Data
{
    public class LoanDTO
    {
        public int LoanId { get; set; }
        public DateTime? LoanDate { get; set; } = DateTime.Today;
        public DateTime? ReturnDate { get; set; }
        public int LibraryBookId { get; set; }
        public LibraryBook LibraryBook { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
