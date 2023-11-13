using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Models.DTOs
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [StringLength(20, ErrorMessage = "Yemek ismi en fazla 20 karekter olmalıdır!")]
        public string Name { get; set; }
        public int Stock { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [StringLength(90, ErrorMessage = "Yemek ismi en fazla 90 karekter olmalıdır!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression("^[0-9]$", ErrorMessage = "Sayısal bir değer olmalıdır.")]
        [Range(1, int.MaxValue, ErrorMessage = "0 dan büyük bir değer olmalı!")]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression("^[0-9]$", ErrorMessage = "Sayısal bir değer olmalıdır!")]
        [Range(1, int.MaxValue, ErrorMessage = "0 dan büyük bir değer olmalı!")]
        public int PrepTime { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Sayısal bir değer olmalıdır!")]
        [Range(0, int.MaxValue, ErrorMessage = "0 dan büyük bir değer olmalı!")]
        public decimal Discount { get; set; }

        public int CategoryID { get; set; }

        public List<DietListDTO> Diets { get; set; }
    }
}
