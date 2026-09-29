using System.ComponentModel.DataAnnotations;


namespace FatOrFit.Models
{
    public class DishElement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        [Range(0.01, double.MaxValue)]
        public double Amount { get; set; } = 0;

    }
}
