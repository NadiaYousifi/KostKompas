using KostKompas.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class GetFoodLogDayModel : PageModel
    {

        // properties 
        public FoodLogService _FoodLogService {  get; set; }

        public Models.FoodLogDay FoodLogDay { get; set; }

        // constructor
        public GetFoodLogDayModel(FoodLogService foodLogService) //dependency injection
        {
            _FoodLogService = foodLogService;
        }

        // OnGet metode
        public IActionResult OnGet()
        {
            FoodLogDay = _FoodLogService.GetFoodLogDayByDate(DateTime.Today);
            if (FoodLogDay == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
    }
}
