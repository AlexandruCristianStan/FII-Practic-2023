using System.ComponentModel.DataAnnotations;

namespace FIIPracticCars.Web.Models.Account
{
  public class LoginModel
  {
    [EmailAddress(ErrorMessage = "The email is invalid!")]
    public required string Email { get; set; }
    [MinLength(10, ErrorMessage = "The password is invalid!!")]
    public required string Password { get; set; }
  }
}
