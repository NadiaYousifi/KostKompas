using KostKompas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
    [Authorize(Roles = "admin")]
    public class GetAllUsersModel : PageModel
    { 
        private UserService _userService;
        public List<Models.User> Users { get; set; }


        public GetAllUsersModel(UserService userService)
        {
            _userService = userService;
        }




        public void OnGet()
        {
            Users = _userService.GetUsers();
        }
    }
}

