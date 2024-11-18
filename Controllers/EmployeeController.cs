using comapny.Data.Models;
using company.Services.Dto;
using company.Services.Helper;
using company.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        public IActionResult Index(string searchInput)
        {
            if (searchInput == null)
            {
                var res = employeeService.getAll();
                return View(res);
            }
            else
            {

                var employees = employeeService.getEmployeeByName(searchInput);
                return View(employees);

            }
        }
        [HttpGet]
        public IActionResult Create() { return View(); }
        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            if(employee.Image is not null)
            {
                employee.ImageURl = DocumentSetting.uploadFile(employee.Image, "images");
            }
            employeeService.add(employee);
            return RedirectToAction("Index");
        }

    }
}
