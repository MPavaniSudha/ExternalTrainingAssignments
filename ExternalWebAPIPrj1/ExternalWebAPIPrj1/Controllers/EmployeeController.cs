using ExternalWebAPIPrj1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExternalWebAPIPrj1.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        EmployeeContext ec = new EmployeeContext();

        [HttpPost]
        public IHttpActionResult AddEmp([FromBody] Employee empl)
        {
            ec.employee.Add(empl);
            ec.SaveChanges();
            if (empl.EmpType=="Permanent")
            {
                empl.Bonus_Status = "Eligible";
                ec.SaveChanges();
                return Ok(empl);
            }
            else
            {
                empl.Bonus_Status = "Not-Eligible";
                ec.SaveChanges();
            }
            return Ok(empl);
        }
       
        [Route("getempbyid")]
        [HttpGet]
        public IHttpActionResult GetEmpById(int id)
        {
            Employee employee = ec.employee.Where(p => p.EmpNO == id) .FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        
        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            var emp = ec.employee.ToList();
            return Ok(emp);
        }

        [Route("AddAddress")]
        [HttpPut]
        public IHttpActionResult AddAddres( int id,[FromBody] Employee emp)
        {
            if (emp.EmpNO == id)
            {
                ec.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                ec.SaveChanges();
            }
            else if(emp!= null)
            {
                return Content(HttpStatusCode.Accepted, emp);
            }
            else
            {
                return NotFound();
            }
            return Ok(emp);
        }

    }
}
