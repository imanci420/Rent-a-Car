using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class MarkService : IMarkService
    {
        private readonly RentACarDBContext context;

        public MarkService(RentACarDBContext context)
        {
            this.context = context;
        }

        public async Task<List<Mark>> GetAllMarks() => await context.Marks.ToListAsync();

        public async Task<Mark> GetMarkById(int id) => await context.Marks.SingleOrDefaultAsync(m => m.Id == id);

        public async Task CreateMark(Mark mark)
        {
            await context.Marks.AddAsync(mark);
            await context.SaveChangesAsync();
        }

        public async Task DeleteMark(int id)
        {
            var mark = await context.Marks.SingleOrDefaultAsync(m => m.Id == id);

            context.Marks.Remove(mark);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMark(Mark mark)
        {
            context.Marks.Update(mark);
            await context.SaveChangesAsync();
        }
    }
}
