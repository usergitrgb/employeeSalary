using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAL;
using DTO;

namespace MvcEmployees.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public async Task<ActionResult> Index(string Search)
        {

            try
            {
                ViewBag.MsjVacio = string.Empty;
                
                List<DTOEmployee> result = null;
                WebApiClass wapi = new WebApiClass();
                result = await wapi.GetEmployees();
                
                // 
                if (!string.IsNullOrEmpty(Search))
                {
                    result = result.Where(w => w.name.ToLower() == Search.ToLower()).ToList();

                }

                foreach (var item in result)
                {
                    if (item.contractTypeName == "HourlySalaryEmployee")
                    {
                        item.annualSalary = (120 * item.hourlySalary) * 12;
                        item.contractTypeName = "Hourly Salary";
                    }
                    else if (item.contractTypeName == "MonthlySalaryEmployee")
                    {
                        item.annualSalary = item.monthlySalary * 12;
                        item.contractTypeName = "Monthly Salary";
                    }                    
                }


                if (result.Count == 0)
                    ViewBag.MsjVacio = "<div class=\"alert alert-danger\" role=\"alert\" >No employees with the name " + Search + "  were found! </div>";

                return View(result);

            }
            catch (Exception ex)
            {
                throw;
            }

        }
       
    }
}
