using KostKompas.Models;
using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;
using System.Runtime.CompilerServices;


namespace KostKompas.Pages.FoodLog
{
    public class LogFoodModel : PageModel
    {
        private FoodService _foodService;
        private FoodLogService _foodLogService;

        public List<Models.Food> Foods { get; set; }
        [BindProperty] 
        public Models.Food LogFood { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int FoodId { get; set; }
        [BindProperty]
        public double WeightInGramsInput { get; set; }
        [BindProperty] 
        public FoodLogDay FoodLogDay { get; set; }
        [BindProperty] 
        public Meal CurrentMeal { get; set; }

        public LogFoodModel(FoodService FoodService, FoodLogService FoodLogService)
        {
            _foodService = FoodService;
            _foodLogService = FoodLogService;
            Foods = _foodService.GetFoods();
        }

        public void OnGet(int id, string name)
        {
            FoodLogDay = _foodLogService.GetFoodLogDayById(id);
            CurrentMeal = FoodLogDay.Meals.First(m => m.Name == name);
        }
        public IActionResult OnPostNameSearch()
        {
            Foods = _foodService.NameSearch(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            // 1. Find den valgte food
            Models.Food selectedFood = _foodService.GetFoodById(FoodId);

            // 2. Lav en "kopi" med brugerens gram
            Models.Food foodToLog = new Models.Food
            {
                Id = selectedFood.Id,
                Name = selectedFood.Name,
                Kcal = selectedFood.Kcal,
                Protein = selectedFood.Protein,
                Fat = selectedFood.Fat,
                Carbohydrate = selectedFood.Carbohydrate,
                Fibre = selectedFood.Fibre,
                WeightInGrams = WeightInGramsInput
            };

            // 3. Log maden i det rigtige måltid
            _foodLogService.LogFood(FoodLogDay,CurrentMeal, foodToLog);

            // 4. Gå tilbage til madloggen
            return RedirectToPage("/FoodLog/GetFoodLogDay");
        }
    }
}
