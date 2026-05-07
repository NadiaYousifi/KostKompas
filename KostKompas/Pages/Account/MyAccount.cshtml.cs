using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Account
{
    public class MyAccountModel : PageModel
    {
        private UserService _userService;
        public Models.User User { get; set; }

        public MyAccountModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            string email = HttpContext.User.Identity.Name;
            User = _userService.GetUsersAsync().Result.FirstOrDefault(u=> u.Email == email);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _userService.UpdateUserAsync(User);
            return RedirectToPage("/Account/MyAccount");
        }
    }
}
