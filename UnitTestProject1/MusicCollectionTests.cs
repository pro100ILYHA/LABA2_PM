using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class MusicCollectionTests
    {
        [TestMethod]
        public void Constructor_LoadTracksPrivate()
        {
            var listViev = new ListView();
            var collection = new MusicCollection(listViev);

            var track = new MusicTrack("IlyaSubbotin", "pesnyaSubika", "jazz", 2007);
            collection.AddTrack(track);

            var tracks = collection.GetTracks();
            var resultListView = collection.GetListView();

            Assert.IsNotNull(resultListView);
            Assert.AreEqual(1, tracks.Count);
            Assert.AreEqual("IlyaSubbotin", tracks[0].Artist);
        }

        [TestMethod]
        public void AddTrackToCollection()
        {
            // Arrange
            var listView = new ListView();
            var collection = new MusicCollection(listView);
            var testTrack = new MusicTrack("IlyaSubbotin", "pesnyaSubika", "jazz", 2007);

            // Act
            collection.AddTrack(testTrack);
            var tracks = collection.GetTracks();

            // Assert
            Assert.AreEqual(1, tracks.Count);
            Assert.AreEqual("pesnyaSubika", tracks[0].Title);
        }

        [TestMethod]
        public void RemoveTrack()
        {
            // Arrange
            var listView = new ListView();
            var collection = new MusicCollection(listView);
            var testTrack = new MusicTrack("IlyaSubbotin", "pesnyaSubika", "jazz", 2007);
            collection.AddTrack(testTrack);

            // Act
            collection.RemoveTrack(testTrack);
            var tracks = collection.GetTracks();

            // Assert
            Assert.AreEqual(0, tracks.Count);
        }

        [TestMethod]
        public void SearchByArtist_FindTrackByArtistName()
        {
            // Arrange
            var listView = new ListView();
            var collection = new MusicCollection(listView);
            var testTrack = new MusicTrack("IlyaSubbotin", "pesnyaSubika", "jazz", 2007);
            collection.AddTrack(testTrack);

            // Act
            collection.SearchByArtist("IlyaSubbotin");

            // Assert
            Assert.AreEqual(1, listView.Items.Count);
            Assert.AreEqual("IlyaSubbotin", listView.Items[0].SubItems[0].Text);
        }

        [TestMethod]
        public void SortByYear_SortTracksByYear()
        {
            // Arrange
            var listView = new ListView();
            var collection = new MusicCollection(listView);
            var track1 = new MusicTrack("IlyaSubbotin", "pesnyaSubika", "jazz", 2007);
            var track2 = new MusicTrack("Subbotin", "Subiktrack", "pop", 2001);
            collection.AddTrack(track1);
            collection.AddTrack(track2);

            // Act
            collection.SortByYear();

            // Assert
            Assert.AreEqual("2001", listView.Items[0].SubItems[3].Text);
            Assert.AreEqual("2007", listView.Items[1].SubItems[3].Text);
        }
    }
}
