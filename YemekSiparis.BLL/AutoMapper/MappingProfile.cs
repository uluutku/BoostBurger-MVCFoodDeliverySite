using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Food, FoodListDTO>().ReverseMap();
            CreateMap<Diet, DietListDTO>().ReverseMap();
            CreateMap<Food, ProductUpdateDTO>().ReverseMap();
            CreateMap<Extra, ExtraListDTO>().ReverseMap();
            CreateMap<Extra, ExtraCreateDTO>().ReverseMap();
            CreateMap<Extra, ExtraUpdateDTO>().ReverseMap();
            CreateMap<Beverage, BeverageListDTO>().ReverseMap();
            CreateMap<Beverage, BeverageCreateDTO>().ReverseMap();
            CreateMap<Beverage, BeverageUpdateDTO>().ReverseMap();
            CreateMap<Food, StockProductsDTO>().ReverseMap();
            CreateMap<Beverage, StockProductsDTO>().ReverseMap();
            CreateMap<Extra, StockProductsDTO>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
            CreateMap<CreateOrderDetailVM, OrderDetail>().ReverseMap();
            CreateMap<CustomerVM, Customer>().ReverseMap();
        }
    }
}
