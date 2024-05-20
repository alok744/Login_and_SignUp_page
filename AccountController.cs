using Login_Signup_page.Migrations;
using Login_Signup_page.Models;
using Login_Signup_page.Models.Account;
using Login_Signup_page.Models.Account.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Login_Signup_page.Controllers.Account
{
    public class AccountController : Controller
    {
        private Login_Dbcontext db;

        public AccountController(Login_Dbcontext DB)
        {
            db = DB;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User1 model)
        {
            if(ModelState.IsValid)
            {
                var data=db.LoginSignUpModel.Where(e => e.UserName == model.UserName).SingleOrDefault();

                db.Add(new User1
                {
                    UserName=model.UserName,
                    Password=model.Password,
                    IsRemember=model.IsRemember
                });
                db.SaveChanges();
                if (data !=null)
                {
                    bool isValid=(data.UserName==model.UserName && data.Password==model.Password);
                    if(isValid)
                    {
                        var identity=new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, model.UserName) },CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal=new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("UserName", model.UserName);                     
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        TempData["errorMessage"] = "Invalid Password";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorMessage"] = "User data not found";
                }
            }
            else
            {
                return View(model);
            }
            return View();
        }

        public IActionResult LogOut()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
       
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(LoginSignUpModel model)
        {
            if (model!=null)
            {
                db.Add(new LoginSignUpModel
                {
                    UserName= model.UserName,
                    Email= model.Email,
                    Mobile=model.Mobile,
                    Password=model.Password,
                    Confirm_Password=model.Confirm_Password,
                    IsActive=model.IsActive,
                    IsRemember=model.IsRemember,
                });
                db.SaveChanges();
                TempData["sucessMessage"] = "Data Added sucessfully";
            }
            else
            {
                TempData["errorMessage"] = "Data is Null";
            }
            return View();
        }
    }
}
