using BasicEmployeeWebApp.Models;
using BasicEmployeeWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicEmployeeWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(bool? asc)
        {
            bool sortDirection = asc.HasValue ? asc.Value : false;
            ViewBag.sortDirection = !sortDirection;

            return View(EmployeeDB.GetInstance().GetEmployees(sortDirection));
        }

        [HttpGet]
        public ActionResult Create()
        {
            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                EmployeeTypes = EmployeeTypeDB.GetInstance().GetEmployeeTypes(),
                EmployeeStatuses = EmployeeStatusDB.GetInstance().GetEmployeeStatuses()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employee.Type = EmployeeTypeDB.GetInstance().FindEmployeeType(employee.Type.Id);
            employee.Status = EmployeeStatusDB.GetInstance().FindEmployeeStatus(employee.Status.Id);
            EmployeeDB.GetInstance().AddEmployee(employee);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int employeeId) {
            EmployeeViewModel viewModel = new EmployeeViewModel()
            {
                Employee = EmployeeDB.GetInstance().FindEmployee(employeeId),
                EmployeeTypes = EmployeeTypeDB.GetInstance().GetEmployeeTypes()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee) {
            ///Update employee
            employee.Type = EmployeeTypeDB.GetInstance().FindEmployeeType(employee.Type.Id);
            EmployeeDB.GetInstance().UpdateEmployee(employee);
            return Redirect("Index");
        }

        [HttpGet]
        ///HTTPGet Delete only returns a html page with the yes/no button
        public ActionResult Delete(int employeeId)
        {
            return View(employeeId);
        }

        [HttpPost]
        [ActionName("Delete")]
        ///HTTPPost DeleteAccepted will be hit if the user presses yes on the delete page above.
        public ActionResult DeleteAccepted(int employeeId)
        {
            //Delete employee
            EmployeeDB.GetInstance().DeleteEmployee(employeeId);
            return Redirect("Index");
        }
    }
}