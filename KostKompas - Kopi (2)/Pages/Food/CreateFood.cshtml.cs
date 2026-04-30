using KostKompas.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class CreateFoodModel : PageModel
    {

        // instance fields
        private FoodService _foodService;

        // property
        [BindProperty]
        public Models.Food Food { get; set; }


        // constructor
        public CreateFoodModel(FoodService foodService)
        {
            _foodService = foodService;
        }

        // metode OnGet
        public IActionResult OnGet()
        {
            return Page(); // genopfrisk siden
        }



        // metode OnPost
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) // tjekker om staten brydes. Passer datatyperne sammen (int først, derefter string = invalid)
            {
                return Page();
            }
            _foodService.AddFood(Food);
            return RedirectToPage("GetAllFoods");
        }
    }
}
