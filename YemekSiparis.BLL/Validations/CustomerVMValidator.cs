using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.ViewModels;

namespace YemekSiparis.BLL.Validations
{
    public class CustomerVMValidator : AbstractValidator<CustomerVM>
    {

        public CustomerVMValidator()
        {

            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(30).WithMessage("İsim alani bos gecilemez. En az 3 en fazla 30 karakter icermelidir.").WithErrorCode("1");
            RuleFor(x => x.Name).Must(Name =>  ConstainsNumber(Name)).WithMessage("İsim alani ozel karakter ve sembol iceremez...").WithErrorCode("2");
            RuleFor(x => x.Address).NotEmpty().MinimumLength(6).MaximumLength(255).WithMessage("İsim alani bos gecilemez. En az 6 en fazla 255 karakter icermelidir. ").WithErrorCode("3");
            RuleFor(x => x.Age).NotEmpty().ExclusiveBetween(18, 120).WithMessage("Gecerli yas araliginda giriniz en az 18 yasinda olmalisiniz...").WithErrorCode("4");
            RuleFor(x => x.Birthdate).Must(Birthdate => BeValidBirthdate(Birthdate)).WithMessage("Dogum yilinizi gecerli bir tarih girmelisiniz...").WithErrorCode("5");
        }
        private bool ConstainsNumber(string name)
        {
            if(name == null) return false;

            foreach (var item in name)
            {
                if (char.IsDigit(item))
                {
                    return false;
                }
                else if (char.IsSymbol(item))
                {
                    return false;
                }
            }
            return true;
        }

        private bool BeValidBirthdate(DateTime birthdate)
        {
            return birthdate.Year < 2005 && birthdate.Year >= 1938  ;
        }

    }
}
