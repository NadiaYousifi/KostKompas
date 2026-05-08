using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class DeleteFoodModel : PageModel
    {
        private FoodService _foodService;

        [BindProperty]
        public Models.Food Food { get; set; }

        public DeleteFoodModel(FoodService foodService)
        {
            _foodService = foodService;
        }

        // metode OnGet
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Food = await _foodService.GetFoodByIdAsync(id);
                return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Models.Food deletedFood = await _foodService.GetFoodByIdAsync(Food.Id);
            _foodService.DeleteFoodAsync(Food.Id);
            if(deletedFood == null)
            {
                return Page();
            }

            return RedirectToPage("GetAllFoods");
        }
    }
}

