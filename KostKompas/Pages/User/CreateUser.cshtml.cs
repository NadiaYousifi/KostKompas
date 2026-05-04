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

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        // constructor
        public CreateUserModel(UserService userService)
        {
            _userService = userService;
            passwordHasher = new PasswordHasher<string>();
        }

        // metode OnGet
        public IActionResult OnGet()
        {
            return Page(); // genopfrisk siden
        }



        // metode OnPost
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) // tjekker om staten brydes. Passer datatyperne sammen (int først, derefter string = invalid)
            {
                return Page();
            }
            _userService.AddUser(User);
            return RedirectToPage("GetAllUsers");
        }

    }
}
