using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class LoggedInFoodModel : PageModel
    {
        [BindProperty]
        public Models.Food Food { get; set; }



        public void OnGet()
        {
        }
    }
}
