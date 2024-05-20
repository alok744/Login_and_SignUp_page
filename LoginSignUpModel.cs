using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Login_Signup_page.Models.Account.ViewModel
{
    public class LoginSignUpModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Password { get; set; }
        public string Confirm_Password { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
        
    }
}
