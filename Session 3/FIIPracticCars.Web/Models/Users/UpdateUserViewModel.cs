using System.ComponentModel.DataAnnotations;

namespace FIIPracticCars.Web.Models.Users
{
    public class UpdateUserViewModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The first name length is invalid!")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "The last name length is invalid!")]
        public string LastName { get; set; }
    }
}
