using KostKompas.Models;
using KostKompas.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace KostKompas.Pages.LogIn
{
    public class LogInPageModel : PageModel
    {

        private UserService _userService;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }


        public LogInPageModel(UserService userService)
        {
            _userService = userService;

        }
        public async Task OnGetAsync()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            List<Models.User> users = await _userService.GetUsersAsync();
            var passwordHasher = new PasswordHasher<string>();
            foreach (Models.User user in users)
            {
                if (Email == user.Email)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, Email) };
                    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                    { 
                        if (Email == "admin@gmail.com") claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    }
                    return RedirectToPage("/FoodLog/GetFoodLogDay");
                }
            }
            Message = "Invalid attempt";
            return Page();
        }
    }
}
