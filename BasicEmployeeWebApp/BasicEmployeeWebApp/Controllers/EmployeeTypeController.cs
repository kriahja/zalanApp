using BasicEmployeeWebApp.Models;
using System.Web.Mvc;

namespace BasicEmployeeWebApp.Controllers
{
    public class EmployeeTypeController : Controller
    {
        // GET: EmployeeType
        public ActionResult Index()
        {
            return View(EmployeeTypeDB.GetInstance().GetEmployeeTypes());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeType employeeType)
        {
            EmployeeTypeDB.GetInstance().AddEmployeeType(employeeType);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Edit(int employeeTypeId)
        {
            EmployeeType emplT = EmployeeTypeDB.GetInstance().FindEmployeeType(employeeTypeId);
            return View(emplT);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeType employeeType)
        {
            ///Update employee
            EmployeeTypeDB.GetInstance().UpdateEmployeeType(employeeType);
            return Redirect("Index");
        }

        [HttpGet]
        ///HTTPGet Delete only returns a html page with the yes/no button
        public ActionResult Delete(int employeeTypeId)
        {
            return View(employeeTypeId);
        }

        [HttpPost]
        [ActionName("Delete")]
        ///HTTPPost DeleteAccepted will be hit if the user presses yes on the delete page above.
        public ActionResult DeleteAccepted(int employeeTypeId)
        {
            //Delete employee
            EmployeeTypeDB.GetInstance().DeleteEmployeeType(employeeTypeId);
            return Redirect("Index");
        }
    }
}