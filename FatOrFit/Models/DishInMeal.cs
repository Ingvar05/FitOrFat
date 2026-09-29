using System.ComponentModel.DataAnnotations;
namespace FatOrFit.Models
{
    public class DishInMeal
    {
        [Key]
        public int Id { get; set; }
        public int DishId { get; set; }
        public Dish? Dish { get; set; } = null!;
        [Range(0.01, double.MaxValue)]
        public double Amount { get; set; } = 0;
        [Required]
        public int MealId { get; set; }
        public Meal? Meal { get; set; } = null!;
    }
}
