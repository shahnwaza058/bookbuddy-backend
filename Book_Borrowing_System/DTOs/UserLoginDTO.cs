using System.ComponentModel.DataAnnotations;

namespace Book_Borrowing_System.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
