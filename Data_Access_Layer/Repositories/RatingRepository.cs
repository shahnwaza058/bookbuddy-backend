using Data_Access_Layer.Data_Context;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class RatingRepository:IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<Ratings> GetRatingById(int id)
        {
            return await _context.Ratings.FindAsync(id);
        }

        public async Task<IEnumerable<Ratings>> GetAllRatings()
        {
            return await _context.Ratings.ToListAsync();
        }
        public async Task<IEnumerable<Ratings>>GetRatingsByUser(int userId)
        {
            return await _context.Ratings.Where(r=>r.UserId == userId).ToListAsync();
        }
        public async Task<IEnumerable<Ratings>> GetRatingsByBook(int bookId)
        {
            return await _context.Ratings.Where(r => r.BookId == bookId).ToListAsync();
        }

        public Ratings AddRating(Ratings rating)
        {
            _context.Ratings.Add(rating);
            return rating;
        }

        public Ratings UpdateRating(Ratings rating)
        {
            _context.Ratings.Update(rating);
            return rating;
        }

        public void DeleteRating(Ratings rating)
        {
            _context.Ratings.Remove(rating);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
