using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace FatOrFit.Models
{
    public class UserProfile:IdentityUser
    {
        [Range(50, 250)]
        public double Height { get; set; } = 0;
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; } 
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
            Male,
            Female
        } 
        public Gender UserGender { get; set; } = Gender.Male;
        public enum Purpose
        {
            LoseWeight,
            MaintainWeight,
            GainWeight
        }
        public Purpose UserPurpose { get; set; } = Purpose.MaintainWeight;
        public static class ActivityLevel
        {
            public const double Sedentary = 1.1;
            public const double LightlyActive = 1.375;
            public const double ModeratelyActive = 1.55;
            public const double VeryActive = 1.725;
            public const double ExtraActive = 1.9;
        }
        [Range(1.0, 2.5)]
        public double UserActivityLevel { get; set; }

        public List<Weight> Weights { get; set; } = new List<Weight>();
        public List<Daybook> Daybooks { get; set; } = new List<Daybook>();
        public List<Dish> Dishes { get; set; } = new List<Dish>();

    }
}
