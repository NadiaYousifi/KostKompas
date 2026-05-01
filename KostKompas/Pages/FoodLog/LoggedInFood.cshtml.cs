using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class LoggedInFoodModel : PageModel
    {
        private FoodService _foodService;
        private FoodLogService _foodLogService;
        [BindProperty]
        public Models.Food Food { get; set; }

        public LoggedInFoodModel(FoodService foodService, FoodLogService foodLogService)
        {
            _foodService = foodService;
            _foodLogService = foodLogService;
        }

        //public IActionResult OnGet(int id)
        //{
        //    Food = _foodService.GetFoodById(id);
        //    if (Food == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}
        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    _foodService.UpdateFood(Food);
        //    return RedirectToPage("GetFoodLogDay");
        //}
    }
}
