using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace InfoPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        [Route("getAllNotes")]
        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            var response = await _noteService.GetNotesAsync();

            return response;
        }

        [HttpPost]
        [Route("insertNote")]
        public async Task<int> InsertAsync([FromBody] Note entity)
        {
            var response = await _noteService.InsertNoteAsync(entity);

            return response;
        }

        [HttpPut]
        [Route("updateNote")]
        public async Task<int> UpdateAsync([FromBody] Note entity)
        {
            var response = await _noteService.UpdateNoteAsync(entity);

            return response;
        }

        [HttpDelete]
        [Route("deleteNote")]
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _noteService.DeleteNoteAsync(id);

            return response;
        }

        [HttpGet]
        [Route("getNotesPointId")]
        public async Task<IEnumerable<Note>> GetNotesPointIdAsync(int pointId)
        {
            var response = await _noteService.GetNotesPointId(pointId);

            return response;
        }
    }
}