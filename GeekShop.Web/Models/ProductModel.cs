﻿using System.ComponentModel.DataAnnotations;

namespace GeekShop.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        [Range(1,100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            if (Name.Length < 24) return Name;
            return $"{Name.Substring(0, 21)} ...";
        }

        public string SubstringDescription()
        {
            if (Description.Length < 350) return Name;
            return $"{Description.Substring(0, 347)} ...";
        }
    }
}
