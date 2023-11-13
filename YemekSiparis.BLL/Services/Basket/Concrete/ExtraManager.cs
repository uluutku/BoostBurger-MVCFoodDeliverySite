using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class ExtraManager : BaseManager<Extra>, IExtraService 
    {
        private readonly IBaseRepository<Extra> _baseRepository;
        public ExtraManager(IBaseRepository<Extra> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<decimal> AdditionAsync(List<Extra> extras = null , List<OrderDetailExtra> detailExtras = null)
        {
            decimal total = 1;
            if(extras != null)
            {
                foreach (Extra extra in extras)
                {
                    total += extra.Price;
                }
            }
            else if(detailExtras != null) 
            {

                foreach (OrderDetailExtra item in detailExtras)
                {
                    Extra extra = await _baseRepository.GetByIdAsync(item.ExtraID);
                    total += extra.Price;

                }

            }
       

            return total;
            
        }
    }
}
