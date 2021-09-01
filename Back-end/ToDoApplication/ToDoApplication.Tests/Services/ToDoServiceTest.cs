using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApplication.Models;
using ToDoApplication.Repositories;
using ToDoApplication.Services;
using Xunit;

namespace ToDoApplication.Tests.Services
{
    public class ToDoServiceTest
    {
        private readonly ToDoService _service;
        private readonly Mock<IRepository<ToDoItem>> _repository = new Mock<IRepository<ToDoItem>>();

        public ToDoServiceTest()
        {
            _service = new ToDoService(_repository.Object);
        }

        [Fact]
        public async void GetByIdAsync_Returns_ToDoItem_If_It_Exist()
        {
            var id = 1;

            var testToDoItem = GetTestedData()[0];

            _repository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(testToDoItem);

            var toDoItem = await _service.GetByIdAsync(id);
            
            Assert.Equal(id, testToDoItem.Id);
        }

        [Fact]
        public async void GetByIdAsync_Returns_ToDoItem_If_It_Not_Exist()
        {
            var id = 1;

            var testToDoItem = GetTestedData()[0];

            _repository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(testToDoItem);

            var toDoItem = await _service.GetByIdAsync(id);

            Assert.Equal(id, testToDoItem.Id);
        }

        [Fact]
        public async void GetAllAsync_Returns_ToDoItems()
        {
            ToDoItem[] testToDoItems = GetTestedData();

            _repository.Setup(x => x.GetAllAsync()).ReturnsAsync(testToDoItems);

            var toDoItems = await _service.GetAllAsync();

            Assert.Equal(toDoItems, testToDoItems);
        }

        [Fact]
        public async void AddAsync_Does_One_Time_And_Return_Nothing()
        {
            var testToDoItem = GetTestedData()[0];

            await _service.AddAsync(testToDoItem);

            _repository.Verify(v => v.AddAsync(testToDoItem), Times.Once());
        }

        [Fact]
        public async void DeleteAsync_Does_One_Time_And_Return_Nothing()
        {
            var testToDoItem = GetTestedData()[0];

            await _service.DeleteAsync(testToDoItem);

            _repository.Verify(v => v.DeleteAsync(testToDoItem), Times.Once());
        }

        [Fact]
        public async void UpdateAsync_Does_One_Time_And_Return_Nothing()
        {
            var testToDoItem = GetTestedData()[0];

            await _service.UpdateAsync(testToDoItem);

            _repository.Verify(v => v.UpdateAsync(testToDoItem), Times.Once());
        }

        private ToDoItem[] GetTestedData() {
            ToDoItem[] testToDoItems = new ToDoItem[2] {
                new ToDoItem
                {
                    Id = 1,
                    Description= "Do Smth1",
                    IsComplete = false
                },
                new ToDoItem
                {
                    Id = 2,
                    Description = "Do Smth2",
                    IsComplete = true
                }
            };

            return testToDoItems;
        }
    }
}
