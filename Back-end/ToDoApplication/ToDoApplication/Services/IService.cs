using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApplication.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
