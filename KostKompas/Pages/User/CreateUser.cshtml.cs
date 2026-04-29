using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
    public class CreateUserModel : PageModel
    {
        private UserService _userService;
        [BindProperty]
        public Models.User User { get; set; }

        public CreateUserModel(UserService userService)
        {
            _userService = userService;
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
            _userService.AddUser(User);
            return RedirectToPage("GetAllUsers");
        }

    }
}
