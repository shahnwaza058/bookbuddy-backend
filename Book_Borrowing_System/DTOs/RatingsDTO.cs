using System.ComponentModel.DataAnnotations;

namespace Book_Borrowing_System.DTOs
{
    public class RatingsDTO
    {

      
        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }

        public string comment { get; set; }
    }
}
