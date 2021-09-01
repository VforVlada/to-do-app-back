using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApplication.Models;
using ToDoApplication.Repositories;

namespace ToDoApplication.Services
{
    public class ToDoService : IService<ToDoItem>
    {
        private readonly IRepository<ToDoItem> _toDoRepository;

        public ToDoService(IRepository<ToDoItem> toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task AddAsync(ToDoItem entity)
        {
            await _toDoRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(ToDoItem entity)
        {
            await _toDoRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _toDoRepository.GetAllAsync(); ;
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _toDoRepository.GetByIdAsync(id); ;
        }

        public async Task UpdateAsync(ToDoItem entity)
        {
            await _toDoRepository.UpdateAsync(entity);
        }
    }
}
