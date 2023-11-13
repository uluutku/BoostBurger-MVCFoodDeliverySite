using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.BLL.Models.DTOs
{
    public class BeverageUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Yemek ismi en fazla 20 karekter olmalıdır!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sayısal bir değer olmalıdır.")]
        [Range(1, int.MaxValue, ErrorMessage = "0 dan büyük bir değer olmalı!")]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sayısal bir değer olmalıdır.")]
        [Range(1, int.MaxValue, ErrorMessage = "0 dan büyük bir değer olmalı!")]
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
