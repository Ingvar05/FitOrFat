using System.ComponentModel.DataAnnotations;


namespace FatOrFit.Models
{
    public class ProductInMeal
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; } = null!;
        [Range(0.01, double.MaxValue)]
        public double Amount { get; set; } = 0;
        [Required]
        public int MealId { get; set; }
        public Meal? Meal { get; set; } = null!;
    }
}
