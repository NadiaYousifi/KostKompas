using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace KostKompas.Pages.Food
{
    public class CreateFoodModel : PageModel
    {
        private FoodService _foodService;
        [BindProperty]
        public Models.Food Food { get; set; } 

        public CreateFoodModel(FoodService foodService)
        {
            _foodService = foodService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _foodService.AddFood(Food);
            return RedirectToPage("GetAllFoods");
        }
    }
}
