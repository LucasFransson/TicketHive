using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Models;

namespace TicketHive.Server.Areas.Identity.Pages.Account
{
    [BindProperties]
    public class RegistrationModel : PageModel
    {
        private readonly SignInManager<UserModel> _signInManager;

        [Required(ErrorMessage = "Username is required")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters")]
        public string? Password { get; set; }

        public RegistrationModel(SignInManager<UserModel> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {     
            if (ModelState.IsValid)
            {
                UserModel newUser = new()
                {
                    UserName = Username
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
            return Page();
        }
    }
}
