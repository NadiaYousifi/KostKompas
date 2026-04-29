using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class GetFoodLogDayModel : PageModel
    {
        private FoodLogService _foodLogService;

        public Models.FoodLogDay FoodLogDay { get; set; }

        public GetFoodLogDayModel(FoodLogService foodLogService)
        {
            _foodLogService = foodLogService;
        }

        public IActionResult OnGet(int id)
        {
            FoodLogDay = _foodLogService.GetFoodLogDayById(id);
            if (FoodLogDay == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
