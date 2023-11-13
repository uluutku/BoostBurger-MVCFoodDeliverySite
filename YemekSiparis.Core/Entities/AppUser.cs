using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.Core.Entities
{
    public class AppUser : IdentityUser
    {

        public Customer Customer { get; set; }

        public int ConfirmCode { get; set; }

    }
}
