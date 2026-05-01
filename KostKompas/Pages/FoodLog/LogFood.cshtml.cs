using KostKompas.Models;
using KostKompas.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;
using System.Runtime.CompilerServices;


namespace KostKompas.Pages.FoodLog
{
    public class LogFoodModel : PageModel
    {

        // instance fields
        private FoodService _foodService;

        private FoodLogService _foodLogService;

    // gemmer adgangen til foodservice (der har listen) og selve madloggen, hvor vi logger maden (foodlogservice)

        public List<Models.Food> Foods { get; set; }
        // listen bruges på LogFood, så fødevarerne vises
        // 

        [BindProperty]
        public Models.Food LogFood { get; set; }
        // ved ikke om der skal BindProperty på 
        // men den fødevare som brugeren vælger, vælges ud fra Id'et (som vi har valgt)


        [BindProperty] 
        public string MealName { get; set; }

        // NameSearch
        [BindProperty] public string SearchString { get; set; }

        [BindProperty]
        public int FoodId { get; set; }

        [BindProperty]
        public double WeightInGrams { get; set; }




        // constructor
        public LogFoodModel(FoodService FoodService, FoodLogService FoodLogService)
        {
            _foodService = FoodService;
            _foodLogService = FoodLogService;
            Foods = _foodService.GetFoods();
        }

        // methods 

        public void OnGet(string mealName)
        {
            MealName = mealName;
        }
        // gør, at vi kan få frem, at det er "Morgenmad", der hentydes til

        // NameSearch 
        public IActionResult OnPostNameSearch()
        {
            Foods = _foodService.NameSearch(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            // 1. Find den valgte food
            Models.Food selectedFood = _foodService.GetFood(FoodId);

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
                WeightInGrams = WeightInGrams
            };

            // 3. Log maden i det rigtige måltid
            _foodLogService.LogFood(DateTime.Today, MealName, foodToLog);

            // 4. Gå tilbage til madloggen
            return RedirectToPage("/FoodLog/GetFoodLogDay");
        }


    }

}
