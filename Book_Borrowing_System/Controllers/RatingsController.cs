using Book_Borrowing_System.DTOs;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
 
        private readonly RatingServices _ratingServices;

        public RatingsController(RatingServices ratingServices)
        {
            
            _ratingServices = ratingServices;
        }

       
        [HttpGet("{bookId}")]
        public async Task<IActionResult> getAllRatingByBookId(int bookId)
        {
            try
            {
                if(bookId==null)
                {
                    return BadRequest("Please provide bookId...!");
                }
                IEnumerable<Ratings> ratings = await _ratingServices.GetRatingsByBook(bookId);
                if (!ratings.Any())
                {
                    return NotFound();
                }
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while Retrieving the Books!");
            }
        }
        [Authorize]
        [HttpPost("{bookId}")]
        public async Task<IActionResult> AddRatingOnBookByUser(int bookId, [FromBody] RatingsDTO ratingsDTO)
        {
            try
            {
                if (bookId == null)
                {
                    return BadRequest("Please provide bookId...!");
                }

                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);


                var rating = new Ratings
                {
                    UserId=loginUser,
                    BookId = bookId,
                    Rating=ratingsDTO.Rating,
                    comment=ratingsDTO.comment,
                };

                Ratings newRating = _ratingServices.AddRating(rating);
                return Ok(new
                {
                    rating,
                    message = "Added successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while adding rating!");
            }
        }

        [Authorize]
        [HttpPut("{ratingId}")]
        public async Task<IActionResult> UpdateRatingOnBookByUser(int ratingId, [FromBody] RatingsDTO ratingsDTO)
        {
            try
            {
                if (ratingId == null)
                {
                    return BadRequest("Please provide ratingId...!");
                }

                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);


                var rating = await _ratingServices.GetRatingById(ratingId);
                

                if (rating == null)
                {
                    return NotFound("No rating found!");
                }
                if (loginUser != rating.UserId)
                {
                    return Unauthorized("Not authorized to update the rating");
                }
                if (!string.IsNullOrEmpty(ratingsDTO.comment))
                {
                    rating.comment = ratingsDTO.comment;
                }
                if (ratingsDTO.Rating!=rating.Rating)
                {
                    rating.Rating = ratingsDTO.Rating;
                    if (ratingsDTO.Rating < 0)
                        rating.Rating = 0;
                }
                
                var updatedRating = _ratingServices.UpdateRating(rating);


                return Ok(new
                {
                    updatedRating,
                    message = "Updated successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while updating rating!");
            }
        }

        [Authorize]
        [HttpDelete("{ratingId}")]
        public async Task<IActionResult> DeleteRatingOnBookByUser(int ratingId)
        {
            try
            {
                if (ratingId == null)
                {
                    return BadRequest("Please provide ratingId...!");
                }

                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);


                var rating = await _ratingServices.GetRatingById(ratingId);

                if (rating == null)
                {
                    return NotFound("No rating found!");
                }
                //Checking if the login user and the book lender is same or not
                if (loginUser != rating.UserId)
                {
                    return Unauthorized("Not authorized to delete the rating");
                }
                _ratingServices.DeleteRating(rating);
                return Ok(new
                {
                    message = "Deleted successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while deleting rating!");
            }
        }

    }
}
