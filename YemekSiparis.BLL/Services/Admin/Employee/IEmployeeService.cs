using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Services.Admin.Employee
{
    public interface IEmployeeService
    {
        Task<List<Core.Entities.Employee>> getAll();
        Task<bool> createEmployee(EmployeeCreateDTO employeeCreateDTO);
        Task<bool> updateEmployee(EmployeeUpdateDTO employeeUpdateDTO);
        Task<bool> FireEmployee(int id);
        Task<bool> HireEmployee(int id);
        Task<EmployeeUpdateDTO> GetEmployee(int id);
    }
}
