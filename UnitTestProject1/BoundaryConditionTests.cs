using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System.Collections.Generic;

namespace MusicCollectionTests
{
    [TestClass]
    public class BoundaryConditionTests
    {
        [TestMethod]
        public void MusicTrack_YearIsZero()
        {
            // Arrange
            var artist = "рокер";
            var title = "рокпесня";
            var genre = "рокнрол";
            var year = 0;

            // Act
            MusicTrack track = new MusicTrack(artist, title, genre, year);

            // Assert
            Assert.AreEqual(0, track.Year);
        }

        [TestMethod]
        public void MusicTrack_PolyaCanBeNull()
        {
            // Arrange
            var artist = "";
            var title = "";
            var genre = "";
            var year = 2000;

            // Act
            MusicTrack track = new MusicTrack(artist, title, genre, year);

            // Assert
            Assert.IsNotNull(track);
            Assert.AreEqual("", track.Artist);
        }

        [TestMethod]
        public void MusicTrack_ToString_IsNotNull()
        {
            // Arrange
            MusicTrack track = new MusicTrack("Певец", "Название", "Жанр", 2000);

            // Act
            var result = track.ToString();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
