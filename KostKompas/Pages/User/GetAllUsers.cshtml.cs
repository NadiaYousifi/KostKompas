using KostKompas.Models;
using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
    public class GetAllUsersModel : PageModel
    {
        private UserService _userService;
        public List<Models.User> Users { get; private set; }

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
