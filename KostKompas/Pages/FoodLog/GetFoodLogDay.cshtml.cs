using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class GetFoodLogDayModel : PageModel
    {
        private FoodLogService _foodLogService;
        public Models.FoodLogDay foodLogDay { get; set; }

        public GetFoodLogDayModel(FoodLogService foodLogService)
        {
            _foodLogService = foodLogService;
        }

        public IActionResult OnGet()
        {
            foodLogDay = _foodLogService.GetFoodLogDayByDate(DateTime.Today);
            return Page();
        }
    }
}
