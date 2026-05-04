using KostKompas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{

    [Authorize(Roles = "admin")]
    public class EditUserModel : PageModel
    {

        // instance fields
        private UserService _userService;

        // property
        [BindProperty]
        public Models.User User { get; set; }

        public EditUserModel(UserService userService)
        {
            _userService = userService;
        }

        // metode OnGet
        public IActionResult OnGet(int id)
        {
            User = _userService.GetUserById(id);
            return Page();
        }

        // metode OnPost
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
