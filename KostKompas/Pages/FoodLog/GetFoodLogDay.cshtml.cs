using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class GetFoodLogDayModel : PageModel
    {
        private FoodLogService _foodLogService;

        [BindProperty] 
        public Models.FoodLogDay FoodLogDay { get; set; }

        public GetFoodLogDayModel(FoodLogService foodLogService) 
        {
            _foodLogService = foodLogService;
        }
        public IActionResult OnGet()
        {
            FoodLogDay = _foodLogService.GetFoodLogDayByDate(DateTime.Today);
            if (FoodLogDay == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
