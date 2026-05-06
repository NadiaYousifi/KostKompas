using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
    public class GetAllUsersModel : PageModel
    {
        // instance fields 
        private UserService _userService;
        public List<Models.User> Users { get; set; }


        // constructor
        public GetAllUsersModel(UserService userService)
        {
            _userService = userService;
        }




        public async Task OnGetAsync()
        {
            Users = await _userService.GetUsersAsync();
        }
    }
}

