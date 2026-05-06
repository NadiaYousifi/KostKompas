using KostKompas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{

    [Authorize(Roles = "admin")]
    public class DeleteUserModel : PageModel
    {

        // instance fields
        private UserService _userService;

        // property
        [BindProperty]
        public Models.User User { get; set; }

        public DeleteUserModel(UserService userService)
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
            Models.User deletedUser = await _userService.GetUserByIdAsync(User.Id);
            await _userService.DeleteUserAsync(User.Id);
            if (deletedUser == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("GetAllUsers");
        }
    }
}

