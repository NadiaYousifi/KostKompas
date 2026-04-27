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

        public IActionResult OnGet(int id)
        {
            Food = _foodService.GetFoodById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Food deletedFood = _foodService.GetFoodById(Food.Id);
            _foodService.DeleteFood(Food.Id);
            if(deletedFood == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("GetAllFoods");
        }
       
    }
}
