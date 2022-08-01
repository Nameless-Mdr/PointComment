using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Interfaces
{
    public interface INoteService
    {
        Task<int> InsertNoteAsync(Note entity);

        Task<IEnumerable<Note>> GetNotesAsync();

        Task<bool> DeleteNoteAsync(int id);

        Task<int> UpdateNoteAsync(Note entity);
    }
}
