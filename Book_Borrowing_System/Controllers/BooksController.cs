using Book_Borrowing_System.DTOs;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookServices _bookServices;
        private readonly UserServices _userServices;
        private readonly RatingServices _ratingServices;

        public BooksController(BookServices bookServices,UserServices userServices,RatingServices ratingService)
        {
            _bookServices = bookServices;
            _userServices = userServices;
            _ratingServices = ratingService;
        }
        [Authorize]
        [HttpPost("lend")]
        public async Task<IActionResult> LendBookByUser([FromBody] BookDTO bookDTO)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);
                var lender = await _userServices.GetUserById(loginUser);

                var book = new Book
                {
                    BookName = bookDTO.BookName,
                    Author = bookDTO.Author,
                    Genre = bookDTO.Genre,
                    Description = bookDTO.Description,
                    ImageUrl=bookDTO.ImageUrl,
                    LentByUserId = loginUser,
                    CurrentlyBorrowedByUserId = null
                };
                lender.TokensAvailable += 1;
                Book newBook=_bookServices.AddBook(book);
                _userServices.Update(lender);
                return Ok(new
                {
                    book = newBook,
                    tokens=lender.TokensAvailable,
                    message = "Book added successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while adding the Book!");
            }
        }


        [Authorize]
        [HttpPut("lend/update-book/{bookId}")]

        public async Task<IActionResult> UpdateLendedBookByUser(int bookId, [FromBody] UpdateBookDTO bookDTO)
        {
            try
            {
                if (bookId==null)
                {
                    return BadRequest("Please provide bookid...!");
                }

                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);
                var book = await _bookServices.GetBookById(bookId);
                var borrower = await _userServices.GetUserById((int)book.CurrentlyBorrowedByUserId);
               
                if (book == null)
                {
                    return NotFound("No book found!");
                }
                if (loginUser != (int)book.LentByUserId)
                {
                    return Unauthorized("Not authorized to update the book");
                }
                if (!string.IsNullOrEmpty(bookDTO.BookName))
                {
                    book.BookName = bookDTO.BookName; 
                }
                if (!string.IsNullOrEmpty(bookDTO.Genre))
                {
                    book.Genre = bookDTO.Genre;
                }
                if (!string.IsNullOrEmpty(bookDTO.Description))
                {
                    book.Description = bookDTO.Description;
                }
                if (!string.IsNullOrEmpty(bookDTO.Author))
                {
                    book.Author = bookDTO.Author;
                }
                if (bookDTO.isBookAvailable && !book.isBookAvailable)
                {
                    book.isBookAvailable = bookDTO.isBookAvailable;
                    //if book made available for other user then removing the access of the user;
                    book.CurrentlyBorrowedByUserId = null;
                    borrower.TokensAvailable += 1;
                    _userServices.Update(borrower);
                }
                var updatedBook =  _bookServices.UpdateBook(book);
                

                return Ok(new
                {
                    updatedBook,
                    message = "Book updated successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while adding the Book!");
            }
        }

        [HttpGet("{bookId}")]

        public async Task<IActionResult> getBookById(int bookId)
        {
            try
            {
                if (bookId == null)
                {
                    return BadRequest("Please provide bookId...!");
                }

                
                var book = await _bookServices.GetBookById(bookId);
                var lender = await _userServices.GetUserById((int)book.LentByUserId);
                var ratings = await _ratingServices.GetRatingsByBook(bookId);
                var ratingsWithUserName = new List<object>();
                foreach (var rating in ratings)
                {
                    var user = await _userServices.GetUserById(rating.UserId);

                    var ratingWithUserName = new
                    {
                       rating.Rating,
                       rating.comment,
                       user.Name
                    };

                    ratingsWithUserName.Add(ratingWithUserName);
                }

                var bookDetails = new
                {
                    book.BookId,
                    book.BookName,
                    book.Genre,
                    book.Description,
                    book.Author,
                    book.ImageUrl,
                    book.CurrentlyBorrowedByUserId,
                    book.isBookAvailable,
                    book.LentByUserId,
                    lendedBy = lender.Name,
                    ratings=ratingsWithUserName
                };

                if (book == null)
                {
                    return NotFound("No book found!");
                }
               
                return Ok(bookDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while retrieving Book!");
            }
        }

        [Authorize]
        [HttpPut("borrow/{bookId}")]
        public async Task<IActionResult> BorrowedBookByUser(int bookId)
        {
            try
            {
                if (bookId == null)
                {
                    return BadRequest("Please provide bookid...!");
                }


                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);
        
                var book = await _bookServices.GetBookById(bookId);
               
                var borrower = await _userServices.GetUserById(loginUser);
                var lender = await _userServices.GetUserById((int)book.LentByUserId);
                if (loginUser == lender.UserId)
                {
                    return BadRequest(new {error= "Lender cannot Borrow own book!!" });
                }
                if (book == null || !book.isBookAvailable)
                {
                    return NotFound(new { error = "No book found or currently unavailable!" });
                }
                if (borrower.TokensAvailable<=0)
                {
                    return Ok(new
                    {
                        book,
                        message = "Insufficient Token!"
                    });
                }
              
                book.isBookAvailable = false;
                book.CurrentlyBorrowedByUserId = loginUser;
                borrower.TokensAvailable -= 1;
                lender.TokensAvailable += 1;
                _bookServices.UpdateBook(book);
                _userServices.Update(borrower);
                _userServices.Update(lender);
                return Ok(new
                {
                    book,
                    tokens=borrower.TokensAvailable,
                    message = "Book Borrowed successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while borrowing the Book!");
            }
        }

        [Authorize]
        [HttpPut("return/{bookId}")]
        public async Task<IActionResult> ReturnBookByUser(int bookId )
        {
            try
            {
                if (bookId == null)
                {
                    return BadRequest("Please provide bookid...!");
                }
                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);
                var book = await _bookServices.GetBookById(bookId);
               
                if(loginUser!=book.CurrentlyBorrowedByUserId)
                {
                    return Unauthorized("Access denied or unauthorized!");
                }
                if (book == null)
                {
                    return NotFound("No book found!");
                }
                book.isBookAvailable = true;
                book.CurrentlyBorrowedByUserId = null;
              
                _bookServices.UpdateBook(book);
                return Ok(new
                {
                    book,
                    message = "Book return successfully!"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while borrowing the Book!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AllBooks()
        {
            try
            {
                IEnumerable<Book> Books = await _bookServices.GetAllBooks();
                if(!Books.Any())
                {
                    return NotFound();
                }
                return Ok(Books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
       
    }
}
