using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace DAL.Interfaces
{
    public interface INoteRepo : IBaseRepo<Note>
    {
        Task<IEnumerable<Note>> GetNotesPointIdAsync(int pointId);
    }
}
