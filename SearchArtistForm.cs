using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class SearchArtistForm : Form
    {
        public string Artist { get; set; }

        public SearchArtistForm()
        {
            this.Text = "Поиск по исполнителю";
            this.Width = 300;
            this.Height = 130;

            var artistLabel = new Label { Text = "Исполнитель:", Location = new System.Drawing.Point(10, 10) };
            var artistTextBox = new TextBox { Location = new System.Drawing.Point(10, 30), Width = 260 };
            var okButton = new Button { Text = "OK", Location = new System.Drawing.Point(10, 60), Size = new System.Drawing.Size(75, 23) };
            var cancelButton = new Button { Text = "Отмена", Location = new System.Drawing.Point(95, 60), Size = new System.Drawing.Size(75, 23) };

            okButton.Click += (s, e) => { Artist = artistTextBox.Text; DialogResult = DialogResult.OK; Close(); };
            cancelButton.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            this.Controls.AddRange(new Control[] { artistLabel, artistTextBox, okButton, cancelButton });
        }
    }
}
