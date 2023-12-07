using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ToDoApp.Controllers;
using ToDoApp.Models;

namespace ToDoApp.Tests
{
    [TestFixture]
    public class ToDoListControllerTests
    {
        [Test]
        public async Task GetList_ShouldReturnListOfItems()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ListDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new ListDbContext(options))
            {
                context.List.Add(new List { Id = 1, title = "TestTitle", description = "TestDescription" });
                context.SaveChanges();
            }

            using (var context = new ListDbContext(options))
            {
                var controller = new ToDoListController(context);

                // Act
                var result = await controller.GetList();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOf<ActionResult<IEnumerable<List>>>(result);

                var resultList = (result.Result as OkObjectResult)?.Value as List<List>;
                Assert.IsNotNull(resultList);
                Assert.AreEqual(1, resultList.Count());
            }
        }

        [Test]
        public async Task GetListById_ShouldReturnItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ListDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new ListDbContext(options))
            {
                context.List.Add(new List { Id = 1, title = "TestTitle", description = "TestDescription" });
                context.SaveChanges();
            }

            using (var context = new ListDbContext(options))
            {
                var controller = new ToDoListController(context);

                // Act
                var result = await controller.GetListById(1);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOf<ActionResult<List>>(result);

                var item = (result.Result as OkObjectResult)?.Value as List;
                Assert.IsNotNull(item);
                Assert.AreEqual(1, item.Id);
            }
        }

        [Test]
        public async Task AddList_ShouldReturnNewItem()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ListDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new ListDbContext(options))
            {
                var controller = new ToDoListController(context);

                // Act
                var result = await controller.AddList(new List { title = "NewTitle", description = "NewDescription" });

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOf<ActionResult<List>>(result);

                var newItem = (result.Result as OkObjectResult)?.Value as List;
                Assert.IsNotNull(newItem);
                Assert.AreEqual("NewTitle", newItem.title);
            }
        }

        // Add similar test methods for UpdateList and DeleteList actions
        // ...

        // Make sure to clean up resources after each test if needed
    }
}
