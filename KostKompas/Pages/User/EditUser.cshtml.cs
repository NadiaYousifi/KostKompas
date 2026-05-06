using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
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
        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _userService.GetUserByIdAsync(id);
            return Page();
        }

        // metode OnPost
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          await _userService.UpdateUserAsync(User);
            return RedirectToPage("GetAllUsers");
        }
    }
}
