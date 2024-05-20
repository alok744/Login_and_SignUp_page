using System.ComponentModel.DataAnnotations;

namespace Login_Signup_page.Models.Account
{
    public class User1
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsRemember { get; set; }
    }
}
