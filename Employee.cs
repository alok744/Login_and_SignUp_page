using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_Signup_page.Models
{
    public class Employee
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Employee_id { get; set; }
        public string Employee_name { get; set; }
        public string Employee_email { get; set;}
        public string Employee_phone { get; set; }
        public int Employee_salary { get; set;}
        public bool Employee_status { get; set;}
    }
}
