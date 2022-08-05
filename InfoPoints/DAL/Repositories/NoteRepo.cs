using DAL.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class NoteRepo : INoteRepo
    {
        private readonly AppDbContext _db;

        public NoteRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var note = await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);

            if (note == null) return false;

            _db.Remove(note);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _db.Notes.ToListAsync();
        }

        public async Task<int> InsertAsync(Note entity)
        {
            await _db.Notes.AddAsync(entity);

            await _db.SaveChangesAsync();

            return entity.Id ?? -1;
        }

        public async Task<int> UpdateAsync(Note entity)
        {
            _db.Update(entity);

            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetNotesPointIdAsync(int pointId)
        {
            var notes = await GetAllAsync();

            return notes.Where(note => note.PointId == pointId);
        }
    }
}
