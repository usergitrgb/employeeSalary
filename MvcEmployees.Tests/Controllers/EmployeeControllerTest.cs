using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcEmployees.Controllers;

namespace MvcEmployees.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public async Task Index()
        {

            // Arrange
            EmployeeController controler = new EmployeeController();

            // act
            ViewResult result = await controler.Index("Juan") as ViewResult;

            // asert
            Assert.IsNotNull(result);
            //Assert.AreEqual("Emplloyee Page", result.ViewBag.Title);

        }
    }
}
