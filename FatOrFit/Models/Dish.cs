using System.ComponentModel.DataAnnotations;

namespace FatOrFit.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public enum DishOrigin
        {
            Basic,
            Custom
        }
        public DishOrigin Origin { get; set; } = DishOrigin.Custom;
        [StringLength(500)]
        public string Description { get; set; } = string.Empty; 
        public List<DishElement> Elements { get; set; } = new List<DishElement>();
        public string? UserProfileId { get; set; }
        public UserProfile? Profile { get; set; }
        public double TotalWeight => Elements.Sum(e => e.Amount);
        public double TotalCalories => Elements.Sum(e => e.Product.Calories * (e.Amount / e.Product.BaseAmount));
        public double Proteins => Elements.Sum(e => e.Product.Proteins * (e.Amount / e.Product.BaseAmount));
        public double Fats => Elements.Sum(e => e.Product.Fats * (e.Amount / e.Product.BaseAmount));
        public double Carbohydrates => Elements.Sum(e => e.Product.Carbohydrates * (e.Amount / e.Product.BaseAmount));
        public double CaloriesPer100g => TotalWeight>0 ? TotalCalories / TotalWeight * 100 : 0;
        public double ProteinsPer100g => TotalWeight > 0 ? Proteins / TotalWeight * 100 : 0;
        public double FatsPer100g => TotalWeight > 0 ? Fats / TotalWeight * 100 : 0;
        public double CarbohydratesPer100g => TotalWeight > 0 ? Carbohydrates / TotalWeight * 100 : 0;
    }
}
