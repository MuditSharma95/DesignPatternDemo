using DesignPatternsDemo.Services;
using System.Web.Mvc;

namespace DesignPatternsDemo.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _employeeService.GetAllEmployee();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(model);
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int employeeID)
        {
            return View(_employeeService.GetByEmployeeID(employeeID));
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                _employeeService.EditEmployee(model);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int employeeID)
        {
            return View(_employeeService.GetByEmployeeID(employeeID));
        }
        [HttpPost]
        public ActionResult Delete(int employeeID)
        {
            _employeeService.DeleteEmployee(employeeID);
            return RedirectToAction("Index", "Employee");
        }
    }
}