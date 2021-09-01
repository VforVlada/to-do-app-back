using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApplication.Models;
using ToDoApplication.Services;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IService<ToDoItem> _toDoService;
        
        public ToDoItemsController(IService<ToDoItem> toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _toDoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _toDoService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ToDoItem entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            await _toDoService.AddAsync(entity);
            return CreatedAtAction(nameof(GetAsync), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ToDoItem entity) ////
        {
            if (entity == null)
            {
                return BadRequest();
            }

            var oldToDoItem = await _toDoService.GetByIdAsync(id);

            if (oldToDoItem == null)
            {
                return NotFound();
            }

            await _toDoService.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ToDoItem = await _toDoService.GetByIdAsync(id);

            if (ToDoItem == null)
            {
                return NotFound();
            }

            await _toDoService.DeleteAsync(ToDoItem);
            return NoContent();
        }
    }
}
