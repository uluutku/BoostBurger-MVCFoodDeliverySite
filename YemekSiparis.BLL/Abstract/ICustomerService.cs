using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Abstract
{
    public interface ICustomerService : IBaseService<Customer>
    {

        Task<int> GetCustomerId(string userId);

    }
}
