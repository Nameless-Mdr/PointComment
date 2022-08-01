using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;
using Service.Interfaces;

namespace Service.Implements
{
    class PointService : IPointService
    {
        private readonly IPointRepo _pointRepo;

        public PointService(IPointRepo pointRepo)
        {
            _pointRepo = pointRepo;
        }

        public async Task<int> InsertPointAsync(Point entity)
        {
            var response = await _pointRepo.InsertAsync(entity);

            return response;
        }

        public async Task<IEnumerable<Point>> GetPointsAsync()
        {
            var response = await _pointRepo.GetAllAsync();

            return response;
        }

        public async Task<bool> DeletePointAsync(int id)
        {
            var response = await _pointRepo.DeleteAsync(id);

            return response;
        }

        public async Task<int> UpdatePointAsync(Point entity)
        {
            var response = await _pointRepo.UpdateAsync(entity);

            return response;
        }
    }
}
