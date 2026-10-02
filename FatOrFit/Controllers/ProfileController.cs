using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using FatOrFit.Models;
using FatOrFit.ViewModes;

namespace FatOrFit.Controllers
{
    [Authorize(Roles = "User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<UserProfile> _userManager;

        public ProfileController(UserManager<UserProfile> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            var model = new ProfileEditViewModel
            {
                Height = user.Height,
                BirthDate = user.BirthDate,
                UserPurpose = user.UserPurpose,
                UserGender = user.UserGender,
                UserActivityLevel = user.UserActivityLevel
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileEditViewModel model)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            if(model.BirthDate > today.AddYears(-14))
            {
                ModelState.AddModelError("BirthDate", "You must be at least 14 years old.");
            }
            else if (model.BirthDate < today.AddYears(-100))
            {
                ModelState.AddModelError("BirthDate", "You must be less than 100 years old.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            user.Height = model.Height;
            user.BirthDate = model.BirthDate;
            user.UserPurpose = model.UserPurpose;
            user.UserGender = model.UserGender;
            user.UserActivityLevel = model.UserActivityLevel;

            user.IsProfileCompleted = true; 

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            return RedirectToAction(nameof(Index));


        }
    }
}
