using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesLib
{

    [TestFixture]
    public class Test
    {
        [Test]
        public void CanCreateList()
        {
            // Arrange
            List myList = new List();

            // Act
            // (No specific action for this test)

            // Assert
            Assert.NotNull(myList);
        }

        [Test]
        public void ListPropertiesAreSet()
        {
            // Arrange
            List myList = new List
            {
                Id = 1,
                title = "Sample Title",
                description = "Sample Description"
            };

            // Act
            // (No specific action for this test)

            // Assert
            Assert.AreEqual(1, myList.Id);
            Assert.AreEqual("Sample Title", myList.title);
            Assert.AreEqual("Sample Description", myList.description);
        }
    }

    // Assuming you have a class like this in your project
    public class List
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

}