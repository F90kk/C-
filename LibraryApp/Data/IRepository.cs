using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Data
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}