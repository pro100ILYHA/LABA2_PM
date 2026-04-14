using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class AddTrackFormTests
    {
        private AddTrackForm _form;

        [TestInitialize]
        public void SetUp()
        {
            _form = new AddTrackForm();
        }

        [TestMethod]
        public void Year_CanBeZero()
        {
            // Arrange
            int expectedYear = 0;

            // Act
            _form.Year = expectedYear;

            // Assert
            Assert.AreEqual(expectedYear, _form.Year);
        }
        [TestMethod]
        public void CanCreateTrack()
        {
            // Arrange
            _form.Artist = "Песняры";
            _form.Title = "Косил ясь";
            _form.Genre = "баллада";
            _form.Year = 1991;

            // Act
            var track = new MusicTrack(_form.Artist, _form.Title, _form.Genre, _form.Year);

            // Assert
            Assert.AreEqual(_form.Artist, track.Artist);
            Assert.AreEqual(_form.Title, track.Title);
            Assert.AreEqual(_form.Genre, track.Genre);
            Assert.AreEqual(_form.Year, track.Year);
        }

        [TestMethod]
        public void WindowCloseOk()
        {
            // Arrange
            DialogResult expectedResult = DialogResult.OK;

            // Act
            _form.DialogResult = expectedResult;

            // Assert
            Assert.AreEqual(expectedResult, _form.DialogResult);
        }
    }
}