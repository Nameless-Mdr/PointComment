using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;
using Service.Interfaces;

namespace Service.Implements
{
    public class NoteService : INoteService
    {
        private readonly INoteRepo _noteRepo;

        public NoteService(INoteRepo noteRepo)
        {
            _noteRepo = noteRepo;
        }

        public async Task<int> InsertNoteAsync(Note entity)
        {
            var response = await _noteRepo.InsertAsync(entity);

            return response;
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            var response = await _noteRepo.GetAllAsync();

            return response ?? new List<Note>();
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var response = await _noteRepo.DeleteAsync(id);

            return response;
        }

        public async Task<int> UpdateNoteAsync(Note entity)
        {
            var response = await _noteRepo.UpdateAsync(entity);

            return response;
        }

        public async Task<IEnumerable<Note>> GetNotesPointId(int pointId)
        {
            var response = await _noteRepo.GetNotesPointIdAsync(pointId);

            return response;
        }
    }
}
