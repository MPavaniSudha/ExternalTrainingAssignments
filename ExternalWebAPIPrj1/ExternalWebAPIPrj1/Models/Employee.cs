using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExternalWebAPIPrj1.Models
{
    public class Employee
    {
        [Key]
        public int EmpNO { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmpType { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Bonus_Status { get; set; }
    }
}