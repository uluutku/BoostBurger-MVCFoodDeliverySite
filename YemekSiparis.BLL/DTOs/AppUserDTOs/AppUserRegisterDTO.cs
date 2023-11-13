using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.BLL.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTO
    {
		[Required(ErrorMessage = "İsim-Soyisim alanı boş bırakılamaz")]
		[MaxLength(30, ErrorMessage = "İsim-Soyisim'e en fazla 30 karakter girilebilir!")]
		[MinLength(2, ErrorMessage = "İsim-Soyisim'e en az 2 karakter girilebilir!")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Tekrar şifre alanı boş bırakılamaz.")]
		[Compare("Password", ErrorMessage = "Şifre ve tekrar şifre alanları eşleşmiyor.")]
		public string ConfirmPassword { get; set; }

        [Required(ErrorMessage =("Telefon alanı boş bırakılamaz. Örn:05XX XXX XXXX"))]
		[RegularExpression(@"^05[0-9]{9}$", ErrorMessage = "Geçerli bir cep telefonu numarası giriniz.")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = ("Adres alanı boş bırakılamaz"))]
		public string Address { get; set; }

		[Required(ErrorMessage = ("Kullanım şartlarını okumalısınız"))]
		public bool KullanimSartlari { get; set; }



    }
}
