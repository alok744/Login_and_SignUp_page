using Login_Signup_page.Models;
using Microsoft.AspNetCore.Mvc;

namespace Login_Signup_page.Controllers
{
    public class EmployeeController : Controller
    {
        private Login_Dbcontext db;

        public EmployeeController(Login_Dbcontext DB)
        {
            db = DB;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Employee_get()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Employee_get(Employee employee)
        {
            if (employee!= null)
            {
               db.Add(new Employee
                {
                    Employee_name = employee.Employee_name,
                    Employee_email = employee.Employee_email,
                    Employee_phone = employee.Employee_phone,
                    Employee_salary = employee.Employee_salary,
                    Employee_status = employee.Employee_status,

                });
                db.SaveChanges();
                TempData["sucessMessage"] = "Data Inserted Sucessfully";
            }
            else
            {
                TempData["errorMessage"] = "InValid Data";
            }
            
            return View();
        }
        public IActionResult Employee_update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employee_update(int id, Employee employee)
        {
           
            if (id != null)
            {
               db.Employee.Update(employee);
               var result = db.SaveChanges();
               TempData["sucessMessage"] = "Data added sucessfully";
             
            }
            else
            {
                TempData["errorMessage"] = "Data is invalid";
            }
            return View();
        }

        public IActionResult Employee_delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Employee_delete(int id, Employee employee)
        {
            if (id != null)
            {
                db.Employee.Remove(employee);
                var result=db.SaveChanges();
                TempData["sucessMessage"] = "Data Deleted sucessfully";
            }
            else
            {
                TempData["errorMessage"] = "Data is invalid";
            }
            return View();
        }

    }
}
