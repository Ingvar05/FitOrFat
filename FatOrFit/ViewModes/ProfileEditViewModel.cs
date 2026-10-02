using System.ComponentModel.DataAnnotations;
using FatOrFit.Models;

namespace FatOrFit.ViewModes
{
    public class ProfileEditViewModel
    {
        [Required]
        [Range(50,250)]
        [Display(Name = "Рост, см")]
        public double Height { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateOnly BirthDate { get; set; }

        [Required]
        [Display(Name = "Цель")]
        public UserProfile.Purpose UserPurpose { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public UserProfile.Gender UserGender { get; set; }


        [Required]
        [Display(Name = "Уровень активности")]
        public UserProfile.ActivityLevel UserActivityLevel { get; set; }


    }
}
