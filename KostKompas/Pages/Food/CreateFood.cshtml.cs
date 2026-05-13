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

        [BindProperty]
        public Models.User User { get; set; }


        // constructor
        public CreateFoodModel(FoodService foodService, UserService userService)
        {
            _foodService = foodService;
            _userService = userService;
        }

        // metode OnGet
        public async Task<IActionResult> OnGet()
        {
            User = await _userService.GetUserByEmailAsync(HttpContext.User.Identity.Name);
            return Page(); // genopfrisk siden
        }



        // metode OnPost
        public async Task<IActionResult> OnPostAsync()
        {
            User = await _userService.GetUserByEmailAsync(HttpContext.User.Identity.Name);
            
            if (!ModelState.IsValid) // tjekker om staten brydes. Passer datatyperne sammen (int først, derefter string = invalid)
            {
                return Page();
            }
            await _foodService.AddFoodAsync(Food);
            return RedirectToPage("GetAllFoods");
        }
    }
}
