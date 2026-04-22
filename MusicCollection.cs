using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class MusicCollection
    {
        private List<MusicTrack> tracks = new List<MusicTrack>();
        private ListView listView;

        public MusicCollection(ListView listView)
        {
            this.listView = listView;
            LoadTracks();
        }

        public List<MusicTrack> GetTracks()
        {
            return tracks;
        }
        public ListView GetListView()
        {
            return listView;
        }

        private void LoadTracks()
        {
            listView.Items.Clear();
            foreach (var track in tracks)
            {
                listView.Items.Add(new ListViewItem(new[]
                {
                    track.Artist,
                    track.Title,
                    track.Genre,
                    track.Year.ToString()
                }));
            }
        }

        public void AddTrack(MusicTrack track)
        {
            tracks.Add(track);
            LoadTracks();
            MessageBox.Show("Трек добавлен.");
        }

        public void RemoveTrack(MusicTrack track)
        {
            // Ищем трек по всем полям, т.к. Contains сравнивает по ссылке
            var found = tracks.Find(t =>
                t.Artist == track.Artist &&
                t.Title == track.Title &&
                t.Genre == track.Genre &&
                t.Year == track.Year);

            if (found != null)
            {
                tracks.Remove(found);
                LoadTracks();
                MessageBox.Show("Трек удалён.");
            }
            else
            {
                MessageBox.Show("Трек не найден в коллекции.");
            }
        }

        public void SearchByArtist(string artist)
        {
            var foundTracks = tracks
                .Where(t => t.Artist.IndexOf(artist,
                    StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (foundTracks.Count > 0)
            {
                listView.Items.Clear();
                foreach (var t in foundTracks)
                {
                    listView.Items.Add(new ListViewItem(new[]
                    {
                        t.Artist, t.Title, t.Genre, t.Year.ToString()
                    }));
                }
                MessageBox.Show($"Найдено треков: {foundTracks.Count}");
            }
            else
            {
                MessageBox.Show("Треки не найдены.");
            }
        }

        public void SortByYear()
        {
            var sortedTracks = tracks.OrderBy(t => t.Year).ToList();
            listView.Items.Clear();
            foreach (var t in sortedTracks)
            {
                listView.Items.Add(new ListViewItem(new[]
                {
                    t.Artist, t.Title, t.Genre, t.Year.ToString()
                }));
            }
            MessageBox.Show("Сортировка по году выполнена.");
        }
    }
}
