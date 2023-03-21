using System.ComponentModel.DataAnnotations;

namespace FIIPracticCars.Web.Models.Users
{
    public class CreateUserViewModel
    {
        [MaxLength(50, ErrorMessage = "The first name length is invalid!")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "The last name length is invalid!")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "The email is invalid!")]
        public string Email { get; set; }

        [MinLength(10, ErrorMessage = "The password is invalid!!")]
        public string Password { get; set; }
    }
}
