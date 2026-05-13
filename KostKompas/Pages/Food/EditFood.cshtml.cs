using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class EditFoodModel : PageModel
    {
        private FoodService _foodService;

        [BindProperty]
        public Models.Food Food { get; set; }

        public EditFoodModel(FoodService foodService)
        {
            _foodService = foodService;
        }

        // OnGet metode

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Food = await _foodService.GetFoodByIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _foodService.UpdateFoodAsync(Food);
            return RedirectToPage("GetAllFoods");
            await _foodService.UpdateFoodAsync(Food);

            return RedirectToPage("GetAllFoods");
        }
    }
}