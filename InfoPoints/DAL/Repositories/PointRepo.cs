using DAL.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PointRepo : IPointRepo
    {
        private readonly AppDbContext _db;

        public PointRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var point = await _db.Points.FirstOrDefaultAsync(x => x.Id == id);

            if (point == null) return false;

            _db.Remove(point);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Point>> GetAllAsync()
        {
            return await _db.Points.ToListAsync();
        }

        public async Task<int> InsertAsync(Point entity)
        {
            await _db.Points.AddAsync(entity);

            await _db.SaveChangesAsync();

            return entity.Id ?? -1;
        }

        public async Task<int> UpdateAsync(Point entity)
        {
            _db.Update(entity);

            return await _db.SaveChangesAsync();
        }
    }
}
