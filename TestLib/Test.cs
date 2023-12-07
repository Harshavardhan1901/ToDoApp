using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
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

        [Test]
        public void AddListToCollection()
        {
            // Arrange
            List myList = new List();
            var myCollection = new List<List>();

            // Act
            myCollection.Add(myList);

            // Assert
            Assert.That(myCollection, Contains.Item(myList));
        }

        [Test]
        public void ListInequality()
        {
            // Arrange
            List myList1 = new List { Id = 1, title = "Title", description = "Description1" };
            List myList2 = new List { Id = 1, title = "Title", description = "Description2" };

            // Act
            // (No specific action for this test)

            // Assert
            Assert.AreNotEqual(myList1, myList2);
        }

    }

    public class List
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

}