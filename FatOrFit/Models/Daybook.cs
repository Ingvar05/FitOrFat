using System.ComponentModel.DataAnnotations;

namespace FatOrFit.Models
{
    public class Daybook
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Range(0, double.MaxValue)]
        public double PlannedCalories { get; set; }
        [Range(0, double.MaxValue)]
        public double PlannedProteins { get; set; }
        [Range(0, double.MaxValue)]
        public double PlannedFats { get; set; }
        [Range(0, double.MaxValue)]
        public double PlannedCarbohydrates { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();
        [Required]
        public string UserProfileId { get; set; } = null!;
        public UserProfile Profile { get; set; } = null!;

    }
}
