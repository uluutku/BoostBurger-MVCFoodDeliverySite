using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Models.ViewModels
{
    public class OrderDetailVM
    {
        public OrderDetailVM()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public List<OrderDetail> OrderDetails{ get; set; }

        public int OrderBagId { get; set; }

        public OrderBag OrderBag { get; set; }
    }
}
