using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.booksDataGridView = new System.Windows.Forms.DataGridView();
            this.openBookButton = new System.Windows.Forms.Button();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.descriptionDetailsTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.genreDetailsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authorDetailsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleDetailsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).BeginInit();
            this.detailsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(232, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Электронная библиотека";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(44, 73);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 22);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // genreComboBox
            // 
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(257, 73);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(150, 24);
            this.genreComboBox.TabIndex = 2;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.genreComboBox_SelectedIndexChanged);
            // 
            // booksDataGridView
            // 
            this.booksDataGridView.AllowUserToAddRows = false;
            this.booksDataGridView.AllowUserToDeleteRows = false;
            this.booksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksDataGridView.Location = new System.Drawing.Point(16, 100);
            this.booksDataGridView.MultiSelect = false;
            this.booksDataGridView.Name = "booksDataGridView";
            this.booksDataGridView.ReadOnly = true;
            this.booksDataGridView.RowHeadersWidth = 51;
            this.booksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksDataGridView.Size = new System.Drawing.Size(770, 300);
            this.booksDataGridView.TabIndex = 3;
            this.booksDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.booksDataGridView_CellContentClick);
            this.booksDataGridView.SelectionChanged += new System.EventHandler(this.booksDataGridView_SelectionChanged);
            // 
            // openBookButton
            // 
            this.openBookButton.Enabled = false;
            this.openBookButton.Location = new System.Drawing.Point(16, 410);
            this.openBookButton.Name = "openBookButton";
            this.openBookButton.Size = new System.Drawing.Size(150, 23);
            this.openBookButton.TabIndex = 4;
            this.openBookButton.Text = "Открыть книгу";
            this.openBookButton.UseVisualStyleBackColor = true;
            this.openBookButton.Click += new System.EventHandler(this.openBookButton_Click);
            // 
            // detailsPanel
            // 
            this.detailsPanel.Controls.Add(this.descriptionDetailsTextBox);
            this.detailsPanel.Controls.Add(this.label5);
            this.detailsPanel.Controls.Add(this.genreDetailsTextBox);
            this.detailsPanel.Controls.Add(this.label4);
            this.detailsPanel.Controls.Add(this.authorDetailsTextBox);
            this.detailsPanel.Controls.Add(this.label3);
            this.detailsPanel.Controls.Add(this.titleDetailsTextBox);
            this.detailsPanel.Controls.Add(this.label2);
            this.detailsPanel.Location = new System.Drawing.Point(16, 440);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(770, 100);
            this.detailsPanel.TabIndex = 5;
            this.detailsPanel.Visible = false;
            // 
            // descriptionDetailsTextBox
            // 
            this.descriptionDetailsTextBox.Location = new System.Drawing.Point(100, 50);
            this.descriptionDetailsTextBox.Multiline = true;
            this.descriptionDetailsTextBox.Name = "descriptionDetailsTextBox";
            this.descriptionDetailsTextBox.ReadOnly = true;
            this.descriptionDetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionDetailsTextBox.Size = new System.Drawing.Size(660, 40);
            this.descriptionDetailsTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Описание:";
            // 
            // genreDetailsTextBox
            // 
            this.genreDetailsTextBox.Location = new System.Drawing.Point(350, 20);
            this.genreDetailsTextBox.Name = "genreDetailsTextBox";
            this.genreDetailsTextBox.ReadOnly = true;
            this.genreDetailsTextBox.Size = new System.Drawing.Size(150, 22);
            this.genreDetailsTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Жанр:";
            // 
            // authorDetailsTextBox
            // 
            this.authorDetailsTextBox.Location = new System.Drawing.Point(100, 20);
            this.authorDetailsTextBox.Name = "authorDetailsTextBox";
            this.authorDetailsTextBox.ReadOnly = true;
            this.authorDetailsTextBox.Size = new System.Drawing.Size(200, 22);
            this.authorDetailsTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Автор:";
            // 
            // titleDetailsTextBox
            // 
            this.titleDetailsTextBox.Location = new System.Drawing.Point(550, 20);
            this.titleDetailsTextBox.Name = "titleDetailsTextBox";
            this.titleDetailsTextBox.ReadOnly = true;
            this.titleDetailsTextBox.Size = new System.Drawing.Size(210, 22);
            this.titleDetailsTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 552);
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.openBookButton);
            this.Controls.Add(this.booksDataGridView);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Электронная библиотека";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).EndInit();
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void booksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Получаем выбранную строку
                var selectedBook = (Book)booksDataGridView.Rows[e.RowIndex].DataBoundItem;

                // Обновляем текстовые поля в detailsPanel
                titleDetailsTextBox.Text = selectedBook.Title;
                authorDetailsTextBox.Text = selectedBook.Author;
                genreDetailsTextBox.Text = selectedBook.Genre;
                descriptionDetailsTextBox.Text = selectedBook.Description;

                // Показываем панель с подробной информацией
                detailsPanel.Visible = true;
                openBookButton.Enabled = true;
            }
        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.DataGridView booksDataGridView;
        private System.Windows.Forms.Button openBookButton;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.TextBox descriptionDetailsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox genreDetailsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox authorDetailsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleDetailsTextBox;
        private System.Windows.Forms.Label label2;
    }
}
