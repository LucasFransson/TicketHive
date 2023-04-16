using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Data.Repositories.Implementations;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class UserDetailsModel : PageModel
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public string? CurrentPassword { get; set; }
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters")]
        public string? NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Passwords dosen't match!")]
        public string? ConfirmPassword { get; set; }
        public string? SelectedCountry { get; set; }

        public IEnumerable<CountryModel>? Countries { get; set; }

        public UserDetailsModel(UserManager<UserModel> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        // hämtar countries och sätter userdetails (selected country)
        public async Task OnGet()
        {
            await LoadCountries();
            await SetUserDetails();
        }

        // kollar om selectedcountry är satt och i såfall uppdaterar country
        public async Task<IActionResult> OnPostChangeCountry()
        {
            if (string.IsNullOrEmpty(SelectedCountry) == false)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                user!.CountryName = SelectedCountry;
                await _userManager.UpdateAsync(user!);
            }
            else
            {
                ModelState.AddModelError(nameof(SelectedCountry), "Country is required!");
            }
            await LoadCountries();
            await SetUserDetails();
            return Page();
        }

        //kollar så att nytt och gammalt lösenord är satt och i såfall ändrar lösenord
        public async Task<IActionResult> OnPostChangePassword()
        {
            if(string.IsNullOrEmpty(CurrentPassword)) 
            {
                ModelState.AddModelError(nameof(CurrentPassword), "Current password is required!");
            }
            if (string.IsNullOrEmpty(NewPassword))
            {
                ModelState.AddModelError(nameof(NewPassword), "New password is required!");
            }
            if (ModelState.IsValid) 
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var result = await _userManager.ChangePasswordAsync(user!, CurrentPassword!, NewPassword!);
                if (result.Succeeded == false) 
                {
                    ModelState.AddModelError(nameof(CurrentPassword), result.Errors.First().Description);
                }
            }
            await LoadCountries();
            await SetUserDetails();
            return Page();
        }

        private async Task LoadCountries()
        {
            Countries = await _unitOfWork.Countries.GetAllAsync();
        }

        private async Task SetUserDetails()
        {
            if (HttpContext.User.IsAuthenticated())
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                SelectedCountry = user!.CountryName;
            }           
        }
    }
}
