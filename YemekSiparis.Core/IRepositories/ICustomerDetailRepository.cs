using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Core.IRepositories
{
    public interface ICustomerDetailRepository : IBaseRepository<Customer>
    {

        Task<List<Customer>> AllIncludeFood();

    }
}
