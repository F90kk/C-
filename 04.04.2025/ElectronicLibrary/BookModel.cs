namespace ElectronicLibrary
{
    public class BookModel
    {
        public string Title { get; set; }
        public AuthorModel Author { get; set; }
        public bool IsAvailable { get; set; }
    }
}