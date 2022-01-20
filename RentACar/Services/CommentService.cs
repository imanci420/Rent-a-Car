using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess;
using RentACar.Interfaces;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Services
{
    public class CommentService : ICommentService
    {
        private readonly RentACarDBContext context;
        public CommentService(RentACarDBContext context)
        {
            this.context = context;
        }

        public async Task CreateComment(Comment comment)
        {
            comment.CreationTime = DateTime.Now;
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await context.Comments.SingleOrDefaultAsync(c => c.Id == id);
            
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetCommentsOfCar(int id) => await context.Comments.Where(c => c.CarId == id).ToListAsync();
    }
}
