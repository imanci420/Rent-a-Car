using Microsoft.AspNetCore.Mvc;
using RentACar.Interfaces;
using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService markService;

        public MarkController(IMarkService markService)
        {
            this.markService = markService;
        }

        [HttpGet("{id}")]
        public async Task<Mark> GetMarkById([FromRoute] int id) => await markService.GetMarkById(id);

        [HttpGet]
        public async Task<List<Mark>> GetMarks() => await markService.GetAllMarks();

        [HttpDelete("delete/{id}")]
        public async Task DeleteMark([FromRoute] int id) => await markService.DeleteMark(id);

        [HttpPost("create")]
        public async Task CreateMark([FromBody] Mark mark) => await markService.CreateMark(mark);

        [HttpPut("update")]
        public async Task UpdateMark([FromBody] Mark mark) => await markService.UpdateMark(mark);

    }
}
