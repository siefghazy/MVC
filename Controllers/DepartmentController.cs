using comapny.Data.Models;
using company.Repo.Interfaces;
using company.Service.interfaces;
using company.Services.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _department;
        public DepartmentController(IDepartmentService departmentInterface)
        {
            _department = departmentInterface;
        }

        public IActionResult Index()
        {
            var departments = _department.getAll().ToList();

            return View(departments);
        }
        [HttpGet]
        public IActionResult Create() { return View(); }
        [HttpPost]
        public IActionResult Create(DepartmentDto department) { _department.add(department); return RedirectToAction("Index"); }
        public IActionResult Details(int id) { var dept = _department.GetById(id); return View(dept); }
        [HttpGet]
        public IActionResult Edit(int id) { var res = _department.GetById(id);  return View(res); }

        [HttpPost]
        public IActionResult Edit(DepartmentDto department) { _department.update(department); return RedirectToAction("Index"); }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var res = _department.GetById(id);

            return View(res);
        }
        [HttpPost]
        public IActionResult Delete(DepartmentDto department) { var iso = department.ID; var name = department.Name; var sief=department.codde; _department.remove(department); return RedirectToAction("Index"); }
    }
}
