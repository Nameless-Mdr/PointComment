using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace InfoPoints.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointsController : ControllerBase
    {
        private readonly IPointService _pointService;

        public PointsController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        [Route("getAllPoints")]
        public async Task<IEnumerable<Point>> GetAllAsync()
        {
            var response = await _pointService.GetPointsAsync();

            return response;
        }

        [HttpPost]
        [Route("insertPoint")]
        public async Task<int> InsertAsync([FromBody] Point entity)
        {
            var response = await _pointService.InsertPointAsync(entity);

            return response;
        }

        [HttpPut]
        [Route("updatePoint")]
        public async Task<int> UpdateAsync([FromBody] Point entity)
        {
            var response = await _pointService.UpdatePointAsync(entity);

            return response;
        }

        [HttpDelete]
        [Route("deletePoint")]
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _pointService.DeletePointAsync(id);

            return response;
        }
    }
}
