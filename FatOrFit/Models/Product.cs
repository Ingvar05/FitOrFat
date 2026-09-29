using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FatOrFit.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue)]
        public double BaseAmount { get; set; } = 100;
        public enum ProductOrigin
        {
           Basic,
           Custom
        }
        [Required]
        public ProductOrigin Origin { get; set; } = ProductOrigin.Custom;
        [Range(0, double.MaxValue)]
        public double Calories { get; set; } = 0;
        [Range(0, double.MaxValue)]
        public double Proteins { get; set; } = 0;
        [Range(0, double.MaxValue)]
        public double Fats { get; set; } = 0;
        [Range(0, double.MaxValue)]
        public double Carbohydrates { get; set; } = 0;
        public bool IsActive { get; set; } = true;
   
        public string? UserProfileId { get; set; }
        public UserProfile? Profile { get; set; }
    }
}
