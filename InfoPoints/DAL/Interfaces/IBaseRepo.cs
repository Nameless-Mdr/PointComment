using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBaseRepo<T>
    {
        Task<int> InsertAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> DeleteAsync(int id);

        Task<int> UpdateAsync(T entity);
    }
}
