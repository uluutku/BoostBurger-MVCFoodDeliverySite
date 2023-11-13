using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.BLL.Validations
{
    public class CreateOrderDetailVMValidator : AbstractValidator<CreateOrderDetailVM>
    {

        public CreateOrderDetailVMValidator()
        {
            RuleFor(a => a.FoodId).GreaterThan(0).WithMessage("Yemek Seçimi Yapmalısınız!").WithErrorCode("1");
            RuleFor(a => a.FoodSize).NotEmpty().WithMessage("Boyut Seçmelisiniz").WithErrorCode("2");
            RuleFor(a => a.Quantity).GreaterThan(0).WithMessage("Adet Seçmelisiniz").WithErrorCode("3");

        }

    }
}
