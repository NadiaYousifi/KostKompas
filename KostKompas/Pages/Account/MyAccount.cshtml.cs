using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Account
{
    public class MyAccountModel : PageModel
    {
        // indtance fields
        private UserService _userService;

        // property 
        [BindProperty]
        public Models.User User { get; set; }


        // constructor 
        public MyAccountModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()  // skal være async, da vi skal hente data fra databasen
        {
            string email = HttpContext.User.Identity.Name; // Hent email fra den loggede ind bruger
            User = _userService.GetUsersAsync().Result.FirstOrDefault(u=> u.Email == email); // Hent brugerdata baseret på email
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _userService.UpdateUserAsync(User);
            return RedirectToPage("/Account/MyAccount");
        }
    }
}
    
