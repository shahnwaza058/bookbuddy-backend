using System.ComponentModel.DataAnnotations;

namespace Book_Borrowing_System.DTOs
{
    public class UpdateBookDTO
    {
        public string BookName { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public bool isBookAvailable { get; set; } = true;

        public int? CurrentlyBorrowedByUserId { get; set; }
    }
}
