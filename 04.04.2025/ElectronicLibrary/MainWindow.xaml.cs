using System;
using System.Windows;

namespace ElectronicLibrary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LibraryViewModel();
        }
    }
}