using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.BLL.Models.DTOs
{
    public class BeverageCreateDTO
    {
        [Required]
        [StringLength(20, ErrorMessage = "İçecek ismi en fazla 10 karekter olmalıdır!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sayısal bir değer olmalıdır!")]
        [Range(1, int.MaxValue, ErrorMessage = "0 dan büyük bir değer olmalı!")]
        public decimal Price { get; set; }
    }
}
