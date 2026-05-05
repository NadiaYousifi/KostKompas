using KostKompas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KostKompas.Pages.User
{
    
    public class CreateUserModel : PageModel
    {
        private UserService _userService;
        private PasswordHasher<string> passwordHasher;

        [BindProperty]
        public Models.User User { get; set; }


        public CreateUserModel(UserService userService)
        {
            _userService = userService;
            passwordHasher = new PasswordHasher<string>();
        }

        public IActionResult OnGet()
        {
            return Page(); 
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }
            User.Password = passwordHasher.HashPassword(null, User.Password);
            _userService.AddUser(User);
            return RedirectToPage("GetAllUsers");
        }
    }
}
