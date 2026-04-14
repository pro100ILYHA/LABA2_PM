    using WindowsFormsApp1;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Windows.Forms;

    namespace WindowsFormsApp1.Tests
    {
        [TestClass]
        public class MusicCollectionFormUITests
        {
            private MusicCollectionForm _form;

            [TestInitialize]
            public void SetUp()
            {
                _form = new MusicCollectionForm();
            }

            [TestMethod]
            public void Form_HasCorrectTitle()
            {
                // Assert
                Assert.AreEqual("Управление музыкальной коллекцией", _form.Text);
            }

            [TestMethod]
            public void Form_IsVisible()
            {
                // Assert
                Assert.IsTrue(_form.Visible);
            }

            [TestMethod]
            public void Form_HasCorrectSize()
            {
                // Assert
                Assert.AreEqual(520, _form.Width);
                Assert.AreEqual(400, _form.Height);
            }
        }
    }