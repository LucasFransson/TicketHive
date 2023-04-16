using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Data.Repositories.Interfaces;
using TicketHive.Server.Models;
using TicketHive.Shared.ViewModels;

namespace TicketHive.Server.Areas.Identity.Pages.Account;

[BindProperties]
public class RegistrationModel : PageModel
{
    private readonly SignInManager<UserModel> _signInManager;
    private readonly IUnitOfWork _unitOfWork;

    [Required(ErrorMessage = "Username is required")]
    [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(5, ErrorMessage = "Password must be at least 5 characters")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Country is required")]
    [MinLength(5, ErrorMessage = "Country needs to be selected")]
    public string? SelectedCountry { get; set; }

    public IEnumerable<CountryModel>? Countries { get; set; }

    public RegistrationModel(SignInManager<UserModel> signInManager, IUnitOfWork unitOfWork)
    {
        _signInManager = signInManager;
        _unitOfWork = unitOfWork;
    }

    public async Task OnGet()
	{
		await LoadCountries();
	}

	public async Task<IActionResult> OnPost()
    {
		if (ModelState.IsValid)
        {
            UserModel newUser = new()
            {
                UserName = Username,
                CountryName = SelectedCountry
		    };

            var registerResult = await _signInManager.UserManager.CreateAsync(newUser, Password!);

            if (registerResult.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(newUser, Password!, false, false);

                if (signInResult.Succeeded)
                {
                    return Redirect("~/");
                }
            }
        }

		await LoadCountries();

		return Page();
    }

	private async Task LoadCountries()
	{
		Countries = await _unitOfWork.Countries.GetAllAsync();
	}
}
