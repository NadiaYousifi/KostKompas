using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class CreateFoodModel : PageModel
    {

        // instance fields
        private FoodService _foodService;
        private UserService _userService;

        // property
        [BindProperty]
        public Models.Food Food { get; set; }



        // constructor
        public CreateFoodModel(FoodService foodService, UserService userService)
        {
            _foodService = foodService;
            _userService = userService;
        }

        // metode OnGet
        public async Task<IActionResult> OnGet()
        {
            Models.User user = await _userService.GetUserByEmailAsync(HttpContext.User.Identity.Name);
            return Page(); // genopfrisk siden
        }



        // metode OnPost
        public async Task<IActionResult> OnPostAsync()
        {
            Models.User user = await _userService.GetUserByEmailAsync(HttpContext.User.Identity.Name);
            if (user.Email != "admin@gmail.com")
                Food.UserEmail = user.Email;
            if (!ModelState.IsValid) // tjekker om staten brydes. Passer datatyperne sammen (int først, derefter string = invalid)
            {
                return Page();
            }
            await _foodService.AddFoodAsync(Food);
            return RedirectToPage("GetAllFoods");
        }
    }
}
