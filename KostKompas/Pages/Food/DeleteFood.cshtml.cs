using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class DeleteFoodModel : PageModel
    {
        // instance fields
        private FoodService _foodService;

        // property
        [BindProperty]
        public Models.Food Food { get; set; }


        // constructor 
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

        // metode OnPost
        public async Task<IActionResult> OnPostAsync()
        {
            Models.Food deletedFood = await _foodService.GetFoodByIdAsync(Food.Id);
            _foodService.DeleteFood(Food.Id);
            if(deletedFood == null)
            {
                return Page();
            }
            return RedirectToPage("GetAllFoods");
        }
       
    }
}

