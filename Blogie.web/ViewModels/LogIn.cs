using System.ComponentModel.DataAnnotations;

namespace Blogie.web.ViewModels
{
    public class LogIn
    {
        [Required(ErrorMessage = "Email is Required !" )]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required !")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
