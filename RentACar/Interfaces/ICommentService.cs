using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface ICommentService
    {
        public Task<List<Comment>> GetCommentsOfCar(int id);
        public Task CreateComment(Comment comment);
        public Task DeleteComment(int id);
    }
}
