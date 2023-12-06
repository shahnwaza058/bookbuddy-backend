using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Contracts
{
    public interface IRatingRepository
    {
        Task<Ratings> GetRatingById(int id);
        Task<IEnumerable<Ratings>> GetAllRatings();
        Task<IEnumerable<Ratings>> GetRatingsByUser(int userId);
        Task<IEnumerable<Ratings>> GetRatingsByBook(int bookId);
        Ratings AddRating(Ratings rating);
        Ratings UpdateRating(Ratings rating);
        void DeleteRating(Ratings rating);
    }
}
