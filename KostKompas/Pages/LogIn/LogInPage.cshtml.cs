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
        //public static User LoggedInUser { get; set; } = null;
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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            List<Models.User> users = _userService.GetUsers();
            foreach (Models.User user in users)
            {
                var passwordHasher = new PasswordHasher<string>();

                if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)


                    if (Email == user.Email)
                    {


                        //LoggedInUser = user;

                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, Email) };
                        if (Email == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));



                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Food/GetAllFoods");

                    }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
