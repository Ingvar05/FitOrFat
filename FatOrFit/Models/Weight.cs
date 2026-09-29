using System.ComponentModel.DataAnnotations;

namespace FatOrFit.Models
{
    public class Weight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public double WeightValue { get; set; } = 0;
        [Required]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required]
        public string UserProfileId { get; set; } = null!;
        public UserProfile Profile { get; set; } = null!;
    }
}
