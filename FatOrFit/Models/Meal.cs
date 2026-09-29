using System.ComponentModel.DataAnnotations;

namespace FatOrFit.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public TimeOnly Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
        [Required]
        public int DaybookId { get; set; } = 0;
        public Daybook Daybook { get; set; } = null!;
        public List<DishInMeal> Dishes { get; set; } = new List<DishInMeal>();
        public List<ProductInMeal> Products { get; set; } = new List<ProductInMeal>();
        public double Calories => Products.Sum(p => p.Product!.Calories * (p.Amount / p.Product!.BaseAmount)) + Dishes.Sum(d => d.Dish!.CaloriesPer100g * (d.Amount / 100));
        public double Proteins => Products.Sum(p => p.Product!.Proteins * (p.Amount / p.Product!.BaseAmount)) + Dishes.Sum(d => d.Dish!.ProteinsPer100g * (d.Amount / 100));
        public double Fats => Products.Sum(p => p.Product!.Fats * (p.Amount / p.Product!.BaseAmount)) + Dishes.Sum(d => d.Dish!.FatsPer100g * (d.Amount / 100));
        public double Carbohydrates => Products.Sum(p => p.Product!.Carbohydrates * (p.Amount / p.Product!.BaseAmount)) + Dishes.Sum(d => d.Dish!.CarbohydratesPer100g * (d.Amount / 100));

    }
}
