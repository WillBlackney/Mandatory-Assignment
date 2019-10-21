using Microsoft.VisualStudio.TestTools.UnitTesting;
using Book_Library;
using System;


namespace Book_Testing_Project
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TitleOutOfRangeHandledCorrectly()
        {
            // Arrange
            string invalidTitle = "1";

            // Act 
            Book book = new Book("Martin Jamshid", invalidTitle,"1234567891123", 20);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ISBNOutOfRangeHandledCorrectly()
        {
            // Arrange
            string invalidISBN = "1";

            // Act 
            Book book = new Book("Martin Jamshid", "How To Teach Programming", invalidISBN, 20);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PageCountOutOfRangeHandledCorrectly()
        {
            // Arrange
            int invalidPageCount = 2000;

            // Act 
            Book book = new Book("Martin Jamshid", "How To Teach Programming",  "1234567891123", invalidPageCount);

            // Assert
            Assert.Fail();
        }
    }
}
