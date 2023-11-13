using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Abstract;
using YemekSiparis.BLL.Services.Basket.Concrete;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Concrete
{
    public class CustomerManager : BaseManager<Customer> ,ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<AppUser> _userManager;

        public CustomerManager(ICustomerRepository customerRepository,UserManager<AppUser> userManager):base(customerRepository)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
        }

        public async Task<int> GetCustomerId(string userId)
        {
            AppUser appUser = await _userManager.FindByIdAsync(userId);
            Customer customer = await _customerRepository.GetByWhereAsync(x => x.AppUserId == appUser.Id);

            return customer.Id;
        }

        public async Task<bool> TAddAsync(Customer entity)
        {
            if (entity != null)
                return await _customerRepository.AddAsync(entity);

            return false;

        }

        public async Task<bool> TAnyAsync(Expression<Func<Customer, bool>> exp)
        {
            if (exp != null)
                return await _customerRepository.AnyAsync(exp);

            return false;
        }

        public async Task<bool> TDeleteAsync(Customer entity)
        {
            if (entity != null)
                return await _customerRepository.DeleteAsync(entity);

            return false;
        }

        public async Task<bool> TDeleteAsync(int id)
        {

            if (id != null)
                return await _customerRepository.DeleteAsync(id);

            return false;
        }

        public async Task<List<Customer>> TGetAllAsync(Expression<Func<Customer, bool>>? exp = null)
        {
            if (exp != null)
                return await _customerRepository.GetAllAsync(exp);

            return await _customerRepository.GetAllAsync();

        }

        public async Task<Customer> TGetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<Customer> TGetByWhereAsync(Expression<Func<Customer, bool>> exp)
        {
            return await _customerRepository.GetByWhereAsync(exp);
        }

        public async Task<bool> THardDeleteAsync(Customer entity)
        {
            if (entity != null)
                return await _customerRepository.HardDeleteAsync(entity);

            return false;
        }

        public async Task<bool> THardDeleteAsync(int id)
        {
            if (id != null)
                return await _customerRepository.HardDeleteAsync(id);

            return false;
        }

        public async Task<bool> TSaveAsync()
        {
            return await _customerRepository.SaveAsync();
        }

        public async Task<bool> TUpdateAsync(Customer entity)
        {
            if (entity != null)
                return await _customerRepository.UpdateAsync(entity);

            return false;
        }
    }
}
