using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FatOrFit.Models
{
    public class UserProfile:IdentityUser
    {
        [Range(50, 250)]
        public double Height { get; set; } = 0;
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
        [NotMapped]
        public int FullAge {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.Now);
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                return age;
            } 
        }
        public enum Gender
        {
            [Display(Name = "Мужской")]
            Male,
            [Display(Name = "Женский")]
            Female
        } 
        public Gender UserGender { get; set; } = Gender.Male;
        public enum Purpose
        {
            [Display(Name = "Снижение веса")]
            LoseWeight,
            [Display(Name = "Поддержание веса")]
            MaintainWeight,
            [Display(Name = "Набор веса")]
            GainWeight
        }
        public Purpose UserPurpose { get; set; } = Purpose.MaintainWeight;
        public enum ActivityLevel
        {
            [Display(Name = "Сидячий образ жизни")]
            Sedentary,
            [Display(Name = "Легкая активность")]
            LightlyActive,
            [Display(Name = "Средняя активность")]
            ModeratelyActive,
            [Display(Name = "Высокая активность")]
            VeryActive,
            [Display(Name = "Экстра-активность")]
            ExtraActive
        }
        public ActivityLevel UserActivityLevel { get; set; } = ActivityLevel.Sedentary;

        [NotMapped]
        public double ActivityCoefficient => UserActivityLevel switch
        {
            ActivityLevel.Sedentary => 1.1,
            ActivityLevel.LightlyActive => 1.375,
            ActivityLevel.ModeratelyActive => 1.55,
            ActivityLevel.VeryActive => 1.725,
            ActivityLevel.ExtraActive => 1.9,
            _ => 1.0
        };

        public bool IsProfileCompleted { get; set; } = false;
        public List<Weight> Weights { get; set; } = new List<Weight>();
        public List<Daybook> Daybooks { get; set; } = new List<Daybook>();
        public List<Dish> Dishes { get; set; } = new List<Dish>();
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
