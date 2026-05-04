using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class EditFoodModel : PageModel
    {
        // instance fields
        private FoodService _foodService;

        // property
        [BindProperty]
        public Models.Food Food { get; set; }

        // constructor 
        public EditFoodModel(FoodService foodService)
        {
            _foodService = foodService;
        }

        // OnGet metode
        public IActionResult OnGet(int id)
        {
            Food = _foodService.GetFoodById(id);
            return Page();
        }

        // OnPost metode
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
