using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoApplication.Controllers;
using ToDoApplication.Models;
using ToDoApplication.Services;
using Xunit;

namespace ToDoApplication.Tests.Controllers
{
    public class ToDoItemsControllerTest
    {
        private readonly ToDoItemsController _controller;
        private readonly Mock<IService<ToDoItem>> _service = new Mock<IService<ToDoItem>>();

        public ToDoItemsControllerTest()
        {
            _controller = new ToDoItemsController(_service.Object);
        }

        [Fact]
        public async void GetByIdAsync_Return_OkResult_If_Item_With_Id_Exists()
        {
            var postId = 1;
            var testToDoItem = GetTestedData();

            _service.Setup(x => x.GetByIdAsync(postId)).ReturnsAsync(testToDoItem);
            var response = await _controller.GetAsync(postId);
            
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetByIdAsync_Return_NotFound_If_Item_With_Id_Not_Exists()
        {
            var postId = 1;
            ToDoItem nullItem = null;

            _service.Setup(x => x.GetByIdAsync(postId)).ReturnsAsync(nullItem);
            var response = await _controller.GetAsync(postId);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async void GetAllAsync_Return_OkResult()
        {
            var response = await _controller.GetAsync();

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void PostAsync_Return_OkResult_If_Posted_Data_Is_Not_Null()
        {
            var testedToDoItem = GetTestedData();

            var response = await _controller.PostAsync(testedToDoItem);

            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public async void PostAsync_Return_BadRequest_If_Posted_Data_Equals_Null()
        {
            var response = await _controller.PostAsync(null);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public async void DeleteAsync_Returns_No_Content_If_Item_With_Id_Exists()
        {
            var id = 1;
            var testToDoItem = GetTestedData();

            _service.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(testToDoItem);

            var response = await _controller.DeleteAsync(id);

            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async void DeleteAsync_Returns_Not_Found_If_Item_With_Id_Not_Exist()
        {
            var id = 1;
            ToDoItem testToDoItem = null;

            _service.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(testToDoItem) ;

            var response = await _controller.DeleteAsync(id);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async void PutAsync_Returns_Not_Found_If_Item_With_Id_Not_Exist()
        {
            var id = 1;
            ToDoItem testToDoItem = GetTestedData();
            ToDoItem nullItem = null;

            _service.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(nullItem);

            var response = await _controller.PutAsync(id, testToDoItem);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async void PutAsync_Returns_Bad_Request_If_Param_Item_Equals_Null()
        {
            var id = 1;
            ToDoItem nullItem = null;

            var response = await _controller.PutAsync(id, nullItem);

            Assert.IsType<BadRequestResult>(response);
        }

        private ToDoItem GetTestedData()
        {
            return new ToDoItem
            {
                Id = 1,
                Description = "Do Smth1",
                IsComplete = false
            };
        }

    }
}
