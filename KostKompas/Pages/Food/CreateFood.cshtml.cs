using KostKompas.Services;
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _foodService.AddFoodAsync(Food);
            return RedirectToPage("GetAllFoods");
        }
    }
}
