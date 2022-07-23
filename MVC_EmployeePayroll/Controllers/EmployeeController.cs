using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using System.Collections.Generic;
using System.Linq;

namespace MVC_EmployeePayroll.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = employeeBL.GetAllEmployees().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult CreateView()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateView([Bind] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                employeeBL.AddEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }
    }
}
