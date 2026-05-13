using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class GetFoodLogDayModel : PageModel
    {
        // fields
        private FoodLogService _foodLogService;
        private UserService _userService;
        // properties 

        [BindProperty] public Models.FoodLogDay FoodLogDay { get; set; }
        [BindProperty] public Models.User User { get; set; }

        // constructor
        public GetFoodLogDayModel(FoodLogService foodLogService, UserService userService) //dependency injection
        {
            _foodLogService = foodLogService;
            _userService = userService;
        }

        // OnGet metode
        public async Task<IActionResult> OnGetAsync()
        {
            string email = HttpContext.User.Identity.Name;
            User = await _userService.GetUserByEmailAsync(email) ?? throw new Exception("User not found");
            FoodLogDay = await _foodLogService.GetFoodLogDayByDateAsync(User, DateTime.Today);
            if (FoodLogDay == null)
            {
                FoodLogDay = new(DateTime.Today, email);
                await _foodLogService.AddFoodLogDayAsync(FoodLogDay);
                FoodLogDay = await _foodLogService.GetFoodLogDayByDateAsync( User , DateTime.Today);
            }
            return Page();
        }
    }
}
