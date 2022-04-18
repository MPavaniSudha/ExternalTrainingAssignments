using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExternalWebAPIPrj1.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext():base("name=Emp")
        {

        }
        public DbSet<Employee> employee { get; set; }
    }
}