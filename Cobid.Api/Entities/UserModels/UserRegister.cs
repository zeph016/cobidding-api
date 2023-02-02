using System.ComponentModel.DataAnnotations;

namespace Cobid.Api.Entities.UserModel
{
    public class UserRegister
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;
        public string NameExtension { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public int UserTypeId { get; set; } = 4;
        public int GenderId { get; set; }
        public DateTime CreatedTimeSpan { get; set; } = DateTime.Now;
        public DateTime UpdatedTimeSpan { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; } = string.Empty;
    }
}
