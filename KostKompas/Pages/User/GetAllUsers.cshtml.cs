using KostKompas.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.User
{
    public class GetAllUsersModel : PageModel
    {
        // instance fields 
        private UserService _userService;

        // property
        public List<Models.User> users { get; private set; }

        // constructor
        public GetAllUsersModel(UserService userService)
        {
            _userService = userService;
        }




        public void OnGet()
        {
            users = _userService.GetUsers();
        }
    }
}

