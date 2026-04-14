using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class MusicTrackTests
    {
        [TestMethod]
        public void ToString_VozvratCorrectFormat()
        {
            // Arrange
            var track = new MusicTrack("Певец", "Песня", "Жанр", 2007);

            // Act
            var result = track.ToString();

            // Assert
            Assert.AreEqual("Певец - Песня (2007) [Жанр]", result);
        }

        [TestMethod]
        public void Constructor_SohraneniyeUstanovlZnacheniy()
        {
            // Arrange
            var testArtist = "КрутойПевец";
            var testTitle = "КрутаяПесня";
            var testGenre = "рокнрол";
            var testYear = 2011;

            // Act
            var track = new MusicTrack(testArtist, testTitle, testGenre, testYear);

            // Assert
            Assert.AreEqual(testArtist, track.Artist);
            Assert.AreEqual(testTitle, track.Title);
            Assert.AreEqual(testGenre, track.Genre);
            Assert.AreEqual(testYear, track.Year);
        }
    }
}
