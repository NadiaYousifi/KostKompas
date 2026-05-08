using KostKompas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace KostKompas.Pages.Account
{

    public class ChangePasswordModel : PageModel
    {
        private UserService _userService;

        [BindProperty]
        public string OldPassword { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public string RepeatPassword { get; set; }

        public ChangePasswordModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        //public IActionResult OnPost()
        //{
        //    var user = _userService.GetUserById(1);

        //    if (user.Password != OldPassword)
        //    {
        //        ModelState.AddModelError("", "Forkert nuværende adgangskode");
        //        return Page();
        //    }

        //    if (NewPassword != RepeatPassword)
        //    {
        //        ModelState.AddModelError("", "Passwords matcher ikke");
        //        return Page();
        //    }

        //    user.Password = NewPassword;
        //    _userService.UpdateUser(user);

        //    return RedirectToPage("/Account/MyAccount");
        //}

        public IActionResult OnPost()
        {

            string email = HttpContext.User.Identity.Name;

            var user = _userService
                .GetUsers()
                .FirstOrDefault(u => u.Email == email);
            var user = _userService.GetUsersAsync().Result.FirstOrDefault(u => u.Email == email);

            var passwordHasher = new PasswordHasher<string>();

            var result = passwordHasher.VerifyHashedPassword(null, user.Password, OldPassword);

            if (result != PasswordVerificationResult.Success)
            {
                ModelState.AddModelError("", "Forkert nuværende adgangskode");
                return Page();
            }

            if (NewPassword != RepeatPassword)
            {
                ModelState.AddModelError("", "De nye adgangskoder matcher ikke");
                return Page();
            }

            user.Password = passwordHasher.HashPassword(null, NewPassword);

            _userService.UpdateUserAsync(user);

            return RedirectToPage("/Account/MyAccount");
        }
    }
}

  
