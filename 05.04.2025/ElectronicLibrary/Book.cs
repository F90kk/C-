using System;

namespace LibraryApp
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string FilePath { get; set; }
        public double UploadProgress { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Description { get; set; }
    }
}