using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class GetFoodLogDayModel : PageModel
    {
        // properties 
        private FoodLogService _foodLogService;

        [BindProperty] public Models.FoodLogDay FoodLogDay { get; set; }

        // constructor
        public GetFoodLogDayModel(FoodLogService foodLogService) //dependency injection
        {
            _foodLogService = foodLogService;
        }

        // OnGet metode
        public async Task<IActionResult> OnGetAsync()
        {
            FoodLogDay = await _foodLogService.GetFoodLogDayByDateAsync(DateTime.Today);
            if (FoodLogDay == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
