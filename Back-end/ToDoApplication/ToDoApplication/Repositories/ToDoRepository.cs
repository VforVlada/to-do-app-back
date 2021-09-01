using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApplication.Context;
using ToDoApplication.Models;

namespace ToDoApplication.Repositories
{
    public class ToDoRepository : IRepository<ToDoItem>
    {
        private readonly TodoContext _context;

        public ToDoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ToDoItem entity)
        {
            await _context.ToDoItems.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ToDoItem entity)
        {
            _context.ToDoItems.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems.AsNoTracking().ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.AsNoTracking().FirstOrDefaultAsync(el => el.Id == id);
        }

        public async Task UpdateAsync(ToDoItem newEntity)
        {
            _context.ToDoItems.Update(newEntity);
            await _context.SaveChangesAsync();
        }
    }
}
