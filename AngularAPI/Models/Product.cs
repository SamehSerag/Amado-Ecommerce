﻿using AngularAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        [Required]
        public string Details_EN { get; set; }
        public string Details_AR { get; set; }
        [DataType(DataType.Currency), Required]
        public decimal price { get; set; }

        [EnumDataType(typeof(Color))]
        public Color Color { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Image")]
        public int ImageId { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Image Image { get; set; }
        public Category Category { get; set; }

        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
