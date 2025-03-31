using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Book> books;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBooks();
            UpdateGenresComboBox();
            UpdateDataGridView();
        }

        private void InitializeBooks()
        {
            books = new List<Book>
            {
                new Book { Title = "Книга 1", Author = "Автор 1", Genre = "Жанр 1", Description = "Описание книги 1" },
                new Book { Title = "Книга 2", Author = "Автор 2", Genre = "Жанр 2", Description = "Описание книги 2" },
                new Book { Title = "Книга 3", Author = "Автор 3", Genre = "Жанр 1", Description = "Описание книги 3" },
                new Book { Title = "Книга 4", Author = "Автор 4", Genre = "Жанр 3", Description = "Описание книги 4" },
                new Book { Title = "Книга 5", Author = "Автор 5", Genre = "Жанр 2", Description = "Описание книги 5" }
            };
        }

        private void UpdateGenresComboBox()
        {
            genreComboBox.Items.Clear();
            genreComboBox.Items.Add("Все жанры");
            var genres = books.Select(b => b.Genre).Distinct().OrderBy(g => g).ToList();
            foreach (var genre in genres)
            {
                genreComboBox.Items.Add(genre);
            }
            genreComboBox.SelectedIndex = 0;
        }

        private void UpdateDataGridView()
        {
            string searchText = searchTextBox.Text.ToLower();
            string selectedGenre = genreComboBox.SelectedItem.ToString();

            var filteredBooks = books
                .Where(b => b.Title.ToLower().Contains(searchText) ||
                            b.Author.ToLower().Contains(searchText) ||
                            b.Genre.ToLower().Contains(searchText))
                .Where(b => selectedGenre == "Все жанры" || b.Genre == selectedGenre)
                .ToList();

            booksDataGridView.DataSource = null;
            booksDataGridView.DataSource = filteredBooks;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void booksDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                var selectedBook = (Book)booksDataGridView.SelectedRows[0].DataBoundItem;
                titleDetailsTextBox.Text = selectedBook.Title;
                authorDetailsTextBox.Text = selectedBook.Author;
                genreDetailsTextBox.Text = selectedBook.Genre;
                descriptionDetailsTextBox.Text = selectedBook.Description;
                detailsPanel.Visible = true;
                openBookButton.Enabled = true;
            }
            else
            {
                detailsPanel.Visible = false;
                openBookButton.Enabled = false;
            }
        }

        private void openBookButton_Click(object sender, EventArgs e)
        {
            if (booksDataGridView.SelectedRows.Count > 0)
            {
                var selectedBook = (Book)booksDataGridView.SelectedRows[0].DataBoundItem;
                MessageBox.Show($"Вы открыли книгу: {selectedBook.Title}\n\n{selectedBook.Description}");
            }
            else
            {
                MessageBox.Show("Выберите книгу для открытия.");
            }
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public string Description { get; set; }
        }
    }
}