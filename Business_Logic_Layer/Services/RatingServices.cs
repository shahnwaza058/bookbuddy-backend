using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class RatingServices
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUnitOfWork _unitOfWork;


        public RatingServices(IRatingRepository ratingRepository, IUnitOfWork unitOfWork)
        {
            _ratingRepository = ratingRepository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<Ratings> GetRatingById(int id)
        {
            return await _ratingRepository.GetRatingById(id);
        }

        public async Task<IEnumerable<Ratings>> GetAllRatings()
        {
            return await _ratingRepository.GetAllRatings();
        }
        public async Task<IEnumerable<Ratings>> GetRatingsByUser(int userId)
        {
            return await _ratingRepository.GetRatingsByUser(userId);
        }
        public async Task<IEnumerable<Ratings>> GetRatingsByBook(int bookId)
        {
            return await _ratingRepository.GetRatingsByBook(bookId);
        }

        public Ratings AddRating(Ratings rating)
        {
            Ratings newRating=_ratingRepository.AddRating(rating);
            _unitOfWork.SaveChanges().Wait();
            return newRating;
        }

        public Ratings UpdateRating(Ratings rating)
        {
            Ratings updatedRating = _ratingRepository.UpdateRating(rating);
            _unitOfWork.SaveChanges().Wait();
            return updatedRating;
        }

        public void DeleteRating(Ratings rating)
        {
            _ratingRepository.DeleteRating(rating);
            _unitOfWork.SaveChanges().Wait();
        }
    }
}
