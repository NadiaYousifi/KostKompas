using KostKompas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
    [Authorize(Roles = "admin")]
    public class DeleteUserModel : PageModel
    {
        private UserService _userService;

        [BindProperty]
        public Models.User User { get; set; }

        public DeleteUserModel(UserService userService)
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
            Models.User deletedUser = _userService.GetUserById(User.Id);
            _userService.DeleteUser(User.Id);
            if (deletedUser == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("GetAllUsers");
        }
    }
}

