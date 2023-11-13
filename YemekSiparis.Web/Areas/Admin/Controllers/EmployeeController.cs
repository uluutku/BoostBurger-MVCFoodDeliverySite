using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.BLL.Services.Admin.Employee;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await employeeService.getAll());
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDTO employeeCreateDTO)
        {
            bool result = await employeeService.createEmployee(employeeCreateDTO);
            if (result)
                return RedirectToAction("Employee", "Admin");
            return View(employeeCreateDTO);
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await employeeService.GetEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateDTO employeeUpdateDTO)
        {
            bool result = await employeeService.updateEmployee(employeeUpdateDTO);
            return RedirectToAction("Employee", "Admin");
        }

        public async Task<IActionResult> Fire(int id)
        {
           await employeeService.FireEmployee(id);
            return RedirectToAction("Employee", "Admin");
        }

        public async Task<IActionResult> Hire(int id)
        {
            await employeeService.HireEmployee(id);
            return RedirectToAction("Employee", "Admin");
        }

    }
}
