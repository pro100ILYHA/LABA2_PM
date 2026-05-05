using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public class AddTrackForm : Form
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public AddTrackForm()
        {
            this.Text = "Добавить трек";
            this.Width = 300;
            this.Height = 230;

            var artistLabel = new Label { Text = "Исполнитель:", Location = new System.Drawing.Point(10, 10) };
            var titleLabel = new Label { Text = "Название:", Location = new System.Drawing.Point(10, 40) };
            var genreLabel = new Label { Text = "Жанр:", Location = new System.Drawing.Point(10, 70) };
            var yearLabel = new Label { Text = "Год:", Location = new System.Drawing.Point(10, 100) };

            var artistTextBox = new TextBox { Location = new System.Drawing.Point(120, 10), Width = 150 };
            var titleTextBox = new TextBox { Location = new System.Drawing.Point(120, 40), Width = 150 };
            var genreTextBox = new TextBox { Location = new System.Drawing.Point(120, 70), Width = 150 };
            var yearTextBox = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 50 };

            var okButton = new Button { Text = "OK", Location = new System.Drawing.Point(10, 140), Size = new System.Drawing.Size(75, 23) };
            var cancelButton = new Button { Text = "Отмена", Location = new System.Drawing.Point(95, 140), Size = new System.Drawing.Size(75, 23) };

            

            okButton.Click += (sender, e) =>
            {
                Artist = artistTextBox.Text;
                Title = titleTextBox.Text;
                Genre = genreTextBox.Text;
                
                if (string.IsNullOrEmpty(Artist))
                {
                    MessageBox.Show("Поле исполнитель не может быть пустым.");
                    return;
                }

                if (string.IsNullOrEmpty(Title))
                {
                    MessageBox.Show("Поле название не может быть пустым.");
                    return;
                }

                if (string.IsNullOrEmpty(Genre))
                {
                    MessageBox.Show("Поле жанр не может быть пустым.");
                    return;
                }

                if (int.TryParse(yearTextBox.Text, out int year))
                {
                    Year = year;
                    if (Year < 0)
                    {
                        MessageBox.Show("Год выпуска не может быть отрицательным.");
                        return;
                    }

                    if (Year > 2026)
                    {
                        MessageBox.Show("Год выпуска не может быть больше текущего.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректный год.");
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();

            };

            cancelButton.Click += (sender, e) => { DialogResult = DialogResult.Cancel; Close(); };

            this.Controls.AddRange(new Control[]
            {
                artistLabel, titleLabel, genreLabel, yearLabel,
                artistTextBox, titleTextBox, genreTextBox, yearTextBox,
                okButton, cancelButton
            });
        }
    }
}
