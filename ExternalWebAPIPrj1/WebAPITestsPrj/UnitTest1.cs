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
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var controller = new EmployeeController();
            Employee emp = new Employee
            {
                EmpType = "Permanent",
            };
            //Act On Test
            IHttpActionResult acr = controller.AddEmp(emp);
            var empl = acr as OkNegotiatedContentResult<Employee>;
            //Assert the result
            Assert.IsNotNull(empl);
            Assert.IsNotNull(empl.Content);
            Assert.AreEqual("Eligible", empl.Content.Bonus_Status);  
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            var controller = new EmployeeController();
            Employee emp = new Employee
            {
                EmpType = "Contractor",
            };
            //Act On Test
            IHttpActionResult acr = controller.AddEmp(emp);
            var empl = acr as OkNegotiatedContentResult<Employee>;
            //Assert the result
            Assert.IsNotNull(empl);
            Assert.IsNotNull(empl.Content);
            Assert.AreEqual("Not-Eligible", empl.Content.Bonus_Status);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Arrange  
            var controller = new EmployeeController();
            // Act on Test  
            var response = controller.GetEmpById(101);
            var cr = response as OkNegotiatedContentResult<Employee>;
            // Assert the result  
            Assert.IsNotNull(cr);
            Assert.IsNotNull(cr.Content);
            Assert.AreEqual("Pavani", cr.Content.FirstName);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            var controller = new EmployeeController();
            Employee emp=new Employee
            {
               Address= "143/67,gandhi nagar,Bangalore",
            };
            //Act on test
            IHttpActionResult res = controller.AddAddres(103,emp);
            var cr = res as NegotiatedContentResult<Employee>;
            // Assert the result 
            Assert.IsNotNull(cr);
            Assert.AreEqual(HttpStatusCode.Accepted, cr.StatusCode);
            Assert.IsNotNull(cr.Content);
        }
    }
}
