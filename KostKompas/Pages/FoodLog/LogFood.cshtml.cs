using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.FoodLog
{
    public class LogFoodModel : PageModel
    {
        private FoodService _foodService;
        private FoodLogService _foodLogService;
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public string MealName { get; set; }
        [BindProperty]
        public List<Models.Food> Foods { get; private set; }
        [BindProperty]
        public Models.Food FoodLog { get; set; }

        public LogFoodModel(FoodService foodService, FoodLogService foodLogService)
        {
            _foodService = foodService;
            _foodLogService = foodLogService;
            Foods = _foodService.GetFoods();
        }

        public void OnGet(string mealName)
        {
            MealName = mealName;
        }
        public IActionResult OnPostNameSearch()
        {
            Foods = _foodService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPost()
        {
            Models.Food selectedFood = _foodService.GetFoodById(FoodLog.Id);
            Models.Food foodToLog = new Models.Food()
            {
                Id = selectedFood.Id,
                Name = selectedFood.Name,
                Kcal = selectedFood.Kcal,
                Protein = selectedFood.Protein,
                Fat = selectedFood.Fat,
                Carbohydrate = selectedFood.Carbohydrate,
                Fibre = selectedFood.Fibre,
                WeightInGrams = selectedFood.WeightInGrams
            };
            _foodLogService.LogFood(DateTime.Today, MealName, foodToLog);
            return RedirectToPage("GetFoodLogDay");
        }
    }
}
