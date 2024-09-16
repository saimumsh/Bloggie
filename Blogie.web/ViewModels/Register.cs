using System.ComponentModel.DataAnnotations;

namespace Blogie.web.ViewModels
{
    public class Register
    {
        [Required(ErrorMessage ="User Name is Required")]
        [Display(Name ="User Name")]
        public string UserName {  get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType (DataType.Password)]
        public string Password {  get; set; }
        [Compare("Password",ErrorMessage ="Password doesn't match")]
        public string ConfirmPassword {  get; set; }
    }
}
