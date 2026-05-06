using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class EditModel : PageModel
    {
        // instance fields
        private FoodService _foodService;

        // property
        [BindProperty]
        public Models.Food Food { get; set; }


        // constructor 
        public EditModel(FoodService FoodService)
        {
            _foodService = FoodService;
        }

        // metode OnGet
        //public IActionResult OnGet(int id)
        //{
        //    Food = _foodService.GetFoodById(id);
        //    if (Food == null)
        //        return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Food = await _foodService.GetFoodByIdAsync(id);

            if (Food == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }






        // metode OnPost
        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    _foodService.UpdateFood(Food);
        //    return RedirectToPage("GetAllFoods");
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            await _foodService.UpdateFoodAsync(Food);

            return RedirectToPage("GetAllFoods");
        }
    }
}
