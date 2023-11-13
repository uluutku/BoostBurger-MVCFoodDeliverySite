using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Entities.Abstract;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Admin.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Core.Entities.Employee> employeeRepository;
        private readonly IMapper mapper;

        public EmployeeService(IBaseRepository<Core.Entities.Employee> employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<bool> createEmployee(EmployeeCreateDTO employeeCreateDTO)
        {
            Core.Entities.Employee employee = mapper.Map<Core.Entities.Employee>(employeeCreateDTO);
            return await employeeRepository.AddAsync(employee);  
        }

        public async Task<bool> FireEmployee(int id)
        {
            return await employeeRepository.DeleteAsync(id);
        }

        public async Task<List<Core.Entities.Employee>> getAll()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<EmployeeUpdateDTO> GetEmployee(int id)
        {
            Core.Entities.Employee employee = await employeeRepository.GetByIdAsync(id);
            return  mapper.Map<EmployeeUpdateDTO>(employee);
        }

        public async Task<bool> HireEmployee(int id)
        {
            Core.Entities.Employee employee = await employeeRepository.GetByIdAsync(id);
            employee.CreatedDate = DateTime.Now;
            return await employeeRepository.UpdateAsync(employee);
        }

        public async Task<bool> updateEmployee(EmployeeUpdateDTO employeeUpdateDTO)
        {
            Core.Entities.Employee employee = mapper.Map<Core.Entities.Employee>(employeeUpdateDTO);
            return await employeeRepository.UpdateAsync(employee);
        }
    }
}
