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


        // onget metode
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Food = await _foodService.GetFoodByIdAsync(id);

            if (Food == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        // onpost metode
        public async Task<IActionResult> OnPostAsync()
        {
            Models.Food? deletedFood = await _foodService.DeleteFoodAsync(Food.Id);

            if (deletedFood == null)
            {
                return Page();
            }

            return RedirectToPage("GetAllFoods");
        }
    }
}

