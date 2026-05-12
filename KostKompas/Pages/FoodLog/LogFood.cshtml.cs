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

        // instance fields
        private FoodService _foodService;
        private FoodLogService _foodLogService;

    // gemmer adgangen til foodservice (der har listen) og selve madloggen, hvor vi logger maden (foodlogservice)

        public List<Models.Food> Foods { get; set; }
        // listen bruges på LogFoodAsync, så fødevarerne vises
        // 

        [BindProperty] public Models.Food LogFood { get; set; }
        // ved ikke om der skal BindProperty på 
        // men den fødevare som brugeren vælger, vælges ud fra Id'et (som vi har valgt)

        // NameSearch
        [BindProperty] public string SearchString { get; set; }

        [BindProperty]
        public int FoodId { get; set; }

        [BindProperty]
        public double WeightInGramsInput { get; set; }

        [BindProperty] public Meal CurrentMeal { get; set; }

        // constructor
        public LogFoodModel(FoodService FoodService, FoodLogService FoodLogService)
        {
            _foodService = FoodService;
            _foodLogService = FoodLogService;
        }

        // methods 

        public async Task OnGetAsync(int id)
        {
            Foods = await _foodService.GetFoodsAsync();
            CurrentMeal = await _foodLogService.GetMealByIdAsync(id);
        }
        // gør, at vi kan få frem, at det er "Morgenmad", der hentydes til

        // NameSearch 
        public IActionResult OnPostNameSearch()
        {
            Foods = _foodService.NameSearch(SearchString).ToList();
            return Page();
        }

        public async Task <IActionResult> OnPostAsync()
        {
            // 1. Find den valgte food
            //Models.Food selectedFood = await _foodService.GetFoodByIdAsync(FoodId);

            // 2. Lav en "kopi" med brugerens gram

            FoodMeal selectedFoodMeal = new FoodMeal(FoodId, CurrentMeal.Id, WeightInGramsInput);

            // 3. Log maden i det rigtige måltid
            await _foodLogService.LogFoodAsync(selectedFoodMeal);


            // 4. Gå tilbage til madloggen
            return RedirectToPage("/FoodLog/GetFoodLogDay");
        }
    }

}
