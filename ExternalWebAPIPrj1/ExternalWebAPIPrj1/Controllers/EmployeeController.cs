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
            if (empl.EmpType == "Permanent")
            {
                empl.Bonus_Status = true;
                ec.SaveChanges();
                return Ok(empl);
            }
            else if (empl.EmpType == "Contractor")
            {
                empl.Bonus_Status = false;
                ec.SaveChanges();
            }
            return Ok(empl);
        }

        [Route("AddAddress")]
        [HttpPost]
        public IHttpActionResult AddAddress([FromBody] Address addr)
        {
            try
            {
                ec.address.Add(addr);
                ec.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Insertion Failed");
            }
            return Ok(addr);
        }
        [Route("getempbyid")]
        [HttpGet]
        public IHttpActionResult GetEmpById(int id)
        {
            Employee employee = new Employee();
            try
            {
                employee = ec.employee.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw new Exception("Please Enter Valid Id");
            }
            return Ok(employee);
        }
        
        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            var emp = ec.employee.ToList();
            return Ok(emp);
        }
    }
}
