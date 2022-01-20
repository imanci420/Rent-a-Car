using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Interfaces
{
    public interface IMarkService
    {
        Task CreateMark(Mark mark);

        Task UpdateMark(Mark mark);

        Task DeleteMark(int id);

        Task<List<Mark>> GetAllMarks();

        Task<Mark> GetMarkById(int id);
    }
}
