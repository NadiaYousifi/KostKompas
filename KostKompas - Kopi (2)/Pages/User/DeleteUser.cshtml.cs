using KostKompas.Sevices;
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


        // constructor 
        public DeleteUserModel(UserService UserService)
        {
            _userService = UserService;
        }

        // metode OnGet
        public IActionResult OnGet(int id)
        {
            User = _userService.GetUser(id);
            //if (Food == null)
            /* return RedirectToPage("/NotFound");*/ //NotFound er ikke defineret endnu
            return Page();
        }

        // metode OnPost
        public IActionResult OnPost()
        {
            Models.User deletedUser = _userService.GetUser(User.Id);
            _userService.DeleteUser(User.Id);
            if (deletedUser == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("GetAllUsers");
        }
    }
}

