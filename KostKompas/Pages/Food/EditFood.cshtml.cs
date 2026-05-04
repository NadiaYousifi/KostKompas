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
        public IActionResult OnGet(int id)
        {
            Food = _foodService.GetFoodById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _foodService.UpdateFood(Food);
            return RedirectToPage("GetAllFoods");
        }
    }
}
