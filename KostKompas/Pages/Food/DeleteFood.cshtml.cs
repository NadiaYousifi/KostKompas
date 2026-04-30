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
        public IActionResult OnGet(int id)
        {
            Food = _foodService.GetFoodById(id);
                return Page();
        }

        // metode OnPost
        public IActionResult OnPost()
        {
            Models.Food deletedFood = _foodService.GetFoodById(Food.Id);
            _foodService.DeleteFood(Food.Id);
            if(deletedFood == null)
            {
                return Page();
            }
            return RedirectToPage("GetAllFoods");
        }
       
    }
}

