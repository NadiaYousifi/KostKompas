using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class GetFoodLogDayModel : PageModel
    {
        // properties 
        private FoodLogService _foodLogService;

        public Models.FoodLogDay FoodLogDay { get; set; }

        // constructor
        public GetFoodLogDayModel(FoodLogService foodLogService) //dependency injection
        {
            _foodLogService = foodLogService;
        }

        // OnGet metode
        public IActionResult OnGet()
        {
            FoodLogDay = _FoodLogService.GetFoodLogDayByDate(DateTime.Today);
            if (FoodLogDay == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
