using System.ComponentModel.DataAnnotations;

namespace Book_Borrowing_System.DTOs
{
    public class BookDTO
    {

        [Required]
        public string BookName { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool isBookAvailable { get; set; } = true;

        public int? CurrentlyBorrowedByUserId { get; set; }
    }
}
