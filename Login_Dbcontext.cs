using Login_Signup_page.Models.Account;
using Login_Signup_page.Models.Account.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Login_Signup_page.Models
{
    public class Login_Dbcontext : DbContext
    {
        public Login_Dbcontext(DbContextOptions<Login_Dbcontext> options) : base(options)
        {

        }
        
        public DbSet<User1> User1 { get; set; }
        public DbSet<LoginSignUpModel> LoginSignUpModel { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}
