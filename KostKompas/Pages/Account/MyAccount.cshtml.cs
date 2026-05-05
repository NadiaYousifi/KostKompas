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

        // metode OnGet
        public void OnGet()
         {
            string email = HttpContext.User.Identity.Name;

            User = _userService.GetUsers().FirstOrDefault(u => u.Email == email);
        }

        // metode OnPost
         public IActionResult OnPost()
           {
              _userService.UpdateUser(User);

              return RedirectToPage("/Account/MyAccount");
            }
        }
    }
    
