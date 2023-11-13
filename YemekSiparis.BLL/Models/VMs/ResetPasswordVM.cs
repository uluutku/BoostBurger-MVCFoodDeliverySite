using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.BLL.Models.VMs
{
    public class ResetPasswordVM
    {
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifre ve tekrar şifre alanları eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
