using ExternalWebAPIPrj1.Controllers;
using ExternalWebAPIPrj1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;


namespace WebAPITestsPrj
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var controller = new EmployeeController();
            Employee emp = new Employee
            {
                FirstName="Valli",
                MiddleName="Sri",
                LastName="Kethineedi",
                EmpType = "Permanent",
                Age=25,
                Gender="Female"
            };
            //Act On Test
            IHttpActionResult acr = controller.AddEmp(emp);
            var empl = acr as OkNegotiatedContentResult<Employee>;
            //Assert the result
            Assert.IsNotNull(empl);
            Assert.IsNotNull(empl.Content);
            Assert.AreEqual(true, empl.Content.Bonus_Status);  
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            var controller = new EmployeeController();
            Employee emp = new Employee
            {
                FirstName = "Dharmik",
                MiddleName = "Vishal",
                LastName = "Sandaka",
                EmpType = "Contractor",
                Age = 28,
                Gender = "Male"
            };
            //Act On Test
            IHttpActionResult acr = controller.AddEmp(emp);
            var empl = acr as OkNegotiatedContentResult<Employee>;
            //Assert the result
            Assert.IsNotNull(empl);
            Assert.IsNotNull(empl.Content);
            Assert.AreEqual(false, empl.Content.Bonus_Status);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange  
            var controller = new EmployeeController();
            // Act on Test  
            var response = controller.GetEmpById(2);
            var cr = response as OkNegotiatedContentResult<Employee>;
            // Assert the result  
            Assert.IsNotNull(cr);
            Assert.IsNotNull(cr.Content);
            Assert.AreEqual("Swetha", cr.Content.FirstName);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            var controller = new EmployeeController();
            Address addr = new Address
            {
                StreetName = "Bala Nagar",
                DoorNo = "146/7D",
                City = "Hyderabad",
                State = "Telangana",
                EmpNo = 4
            };
            //Act On Test
            IHttpActionResult acr = controller.AddAddress(addr);
            var addrs = acr as OkNegotiatedContentResult<Address>;
            //Assert the result
            Assert.IsNotNull(addrs);
            Assert.IsNotNull(addrs.Content);
            Assert.AreEqual(4, addrs.Content.EmpNo);
        }
    }
}
