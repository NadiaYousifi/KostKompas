using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
    public class EditUserModel : PageModel
    {
        private UserService _userService;
        [BindProperty]
        public Models.User User { get; set; }

        public EditUserModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet(int id)
        {
            User = _userService.GetUserById(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.UpdateUser(User);
            return RedirectToPage("GetAllUsers");
        }
    }
}
