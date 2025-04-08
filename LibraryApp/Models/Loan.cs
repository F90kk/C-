namespace LibraryApp.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Borrower { get; set; }
        public string LoanDate { get; set; }
        public string ReturnDate { get; set; }
        public Book Book { get; set; } // Навигационное свойство
    }
}