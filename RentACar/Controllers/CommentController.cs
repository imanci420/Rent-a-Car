using Microsoft.AspNetCore.Mvc;
using RentACar.Interfaces;
using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task CreateComment([FromBody] Comment comment) => await commentService.CreateComment(comment);

        [HttpDelete("delete/{id}")]
        public async Task DeleteComment([FromRoute] int id) => await commentService.DeleteComment(id);

        [HttpGet("car/{id}")]
        public async Task<List<Comment>> GetCommentOfCar([FromRoute] int id) => await commentService.GetCommentsOfCar(id);

    }
}
