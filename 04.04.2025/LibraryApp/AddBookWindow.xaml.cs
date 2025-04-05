using System.Windows;

namespace LibraryApp
{
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
            DataContext = new AddBookViewModel(this);
        }
    }
}