using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
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
        public IActionResult OnGet(int id)
        {
            User = _userService.GetUserById(id);
            return Page();
        }

        // metode OnPost
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

