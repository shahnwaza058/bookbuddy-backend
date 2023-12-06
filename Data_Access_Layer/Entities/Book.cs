using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Book name should atleast 3 character long...")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author  { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image url is required")]
        public string ImageUrl { get; set; }

        public bool isBookAvailable { get; set; } = true;

        public int? LentByUserId { get; set; }

        public int? CurrentlyBorrowedByUserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Ratings> Ratings { get; set; }

    }
}
