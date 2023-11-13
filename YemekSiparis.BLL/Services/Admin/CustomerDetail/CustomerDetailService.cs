using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Admin.CustomerDetail
{
    public class CustomerDetailService : ICustomerDetailService
    {
        private readonly ICustomerDetailRepository customerDetailRepository;

        public CustomerDetailService(ICustomerDetailRepository customerDetailRepository)
        {
            this.customerDetailRepository = customerDetailRepository;
        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customers = await customerDetailRepository.AllIncludeFood();
            return customers;
        }
    }
}
