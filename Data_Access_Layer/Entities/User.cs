using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entities
{
    public class User
    {

        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength =3,ErrorMessage ="Name should atleast 3 character long...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public int TokensAvailable { get; set; } = 1;
        
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set;}

        [JsonIgnore]
        public virtual ICollection<Ratings> Ratings { get; set; }

    }
}
