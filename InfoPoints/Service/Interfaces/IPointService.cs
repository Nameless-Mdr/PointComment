using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IPointService
    {
        Task<int> InsertPointAsync(Point entity);

        Task<IEnumerable<Point>> GetPointsAsync();

        Task<bool> DeletePointAsync(int id);

        Task<int> UpdatePointAsync(Point entity);
    }
}
