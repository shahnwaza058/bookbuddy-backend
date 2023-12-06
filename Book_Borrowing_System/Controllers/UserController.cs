using Book_Borrowing_System.DTOs;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly BookServices _bookServices;


        private readonly PasswordHashService _passwordHashService;

        private readonly TokenService _tokenService;

        public UserController(UserServices userServices, PasswordHashService passwordHashService, TokenService tokenService, BookServices bookServices)
        {
            _userServices = userServices;   
            _passwordHashService = passwordHashService; 
            _tokenService = tokenService;
            _bookServices = bookServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLogin)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userServices.GetUserByUserName(userLogin.userName);
            if (user == null || !_passwordHashService.VerifyPassword(userLogin.password, user.Password))
            {
                return Unauthorized("Invalid email or password");
            }
            var token = _tokenService.GenerateToken(user.UserId, user.UserName);
            // Create a cookie
            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Enable this for HTTPS
                SameSite = SameSiteMode.Strict, // Adjust as needed (Strict, Lax, None)
                Expires = DateTime.UtcNow.AddDays(7) // Set expiration as needed
            });

            var response = new
            {
                user.UserId,
                user.UserName,
                user.Name,
                user.TokensAvailable,
                token,
                message="Login Successfully",
            };
            return Ok(response);

        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return Ok(new {message="Logout Successfully!"});

        }
        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            try
            {
                IEnumerable<User> Users = await _userServices.GetAllUsers();
                var filteredUsers = Users.Select(user => new
                {
                    UserId=user.UserId,
                    UserName = user.UserName,
                    Name = user.Name,
                    TokensAvailable = user.TokensAvailable
                }).ToList();

                if (!Users.Any())
                {
                    return NotFound();
                }
                return Ok(filteredUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while Retrieving the Users!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetUserDetailsById(int id)
        {
            try
            {
                var user = await _userServices.GetUserById(id);
               
                var usedDetail = new
                {
                    user.UserId,
                    user.Name,
                    user.UserName,
                    user.TokensAvailable
                }


                ;
                return Ok(usedDetail);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An Error occurred while Retrieving the Users!");
            }

        }
        [Authorize]
        [HttpGet("books-lended")]
        public async Task<IActionResult> AllBooksLendedByUser()
        {
            try
            {
                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);
                IEnumerable<Book> books = await _bookServices.GetBooksByLendUser(loginUser);

                if (!books.Any())
                {
                    return NotFound();
                }

                var booksWithUserDetails = new List<object>();

                foreach (var book in books)
                {   
                    if(book.CurrentlyBorrowedByUserId!=null)
                    {
                        var user = await _userServices.GetUserById((int)book.CurrentlyBorrowedByUserId);

                        var bookWithUserDetails = new
                        {
                            book,
                            BorrowedBy = new
                            {
                                user.UserId,
                                user.Name,
                                user.UserName,
                                user.TokensAvailable
                                // Include other user details as needed
                            }
                        };
                        booksWithUserDetails.Add(bookWithUserDetails);
                    }
                    else {
                        var bookWithUserDetails = new
                        {
                            Book = book,
                           
                        };
                        booksWithUserDetails.Add(bookWithUserDetails);
                    }
                   
                }

                return Ok(booksWithUserDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while Retrieving the Books!");
            }
        }

        [Authorize]
        [HttpGet("books-borrowed")]
        public async Task<IActionResult> AllBooksBorrowedByUser()
        {
            try
            {
                var userIdClaim = HttpContext.User.Claims.FirstOrDefault();
                int loginUser = int.Parse(userIdClaim.Value);
                IEnumerable<Book> Books = await _bookServices.GetBooksByBorrowedUser(loginUser);
               
                if (!Books.Any())
                {
                    return NotFound();
                }
                var booksWithUserDetails = new List<object>();

                foreach (var book in Books)
                {
                    var user = await _userServices.GetUserById((int)book.LentByUserId);

                    var bookWithUserDetails = new
                    {
                        Book = book,
                        LendedBy = new
                        {
                            user.UserId,
                            user.Name,
                            user.UserName,
                            user.TokensAvailable
                            // Include other user details as needed
                        }
                    };

                    booksWithUserDetails.Add(bookWithUserDetails);
                }

                return Ok(booksWithUserDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Error occurred while Retrieving the Books!");
            }
        }
    }
}
