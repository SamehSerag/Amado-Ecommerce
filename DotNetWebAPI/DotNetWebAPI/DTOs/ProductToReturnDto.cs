﻿using AngularProject.Models;

namespace AngularAPI.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string Details_EN { get; set; }
        public string Details_AR { get; set; }
        public decimal price { get; set; }

        public string Color { get; set; }
        public int Quantity { get; set; }
        public ICollection<string>? Images { get; set; }
        public string? Category { get; set; }
    }
}