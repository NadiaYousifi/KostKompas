using KostKompas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KostKompas.Pages.User
{
    public class CreateUserModel : PageModel
    {
        // instance fields
        private UserService _userService;
        private PasswordHasher<string> passwordHasher;

        // property
        [BindProperty]
        public Models.User User { get; set; }


        // constructor
        public CreateUserModel(UserService userService)
        {
            _userService = userService;
            passwordHasher = new PasswordHasher<string>();

        }

        // metode OnGet
        public IActionResult OnGet()
        {
            return Page();
        }



        // metode OnPost
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }
            User.Password = passwordHasher.HashPassword(null, User.Password);
            await _userService.AddUserAsync(User);
            return RedirectToPage("GetAllUsers");
        }

    }
}
