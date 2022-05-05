﻿namespace AngularAPI.Models
{
    public class ProductSearchModel
    {
        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; } = 0;
        public string? Sortby { get; set; }
        public string? Sortdir { get; set; }
        public List<int>? Category { get; set; }
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public bool IsValidRange => MaxPrice >= MinPrice;
    }
}
