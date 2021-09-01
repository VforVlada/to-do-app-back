using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApplication.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T newEntity);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
