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
        // listen bruges på LogFood, så fødevarerne vises
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

        [BindProperty] public FoodLogDay FoodLogDay { get; set; }
        [BindProperty] public Meal CurrentMeal { get; set; }

        // constructor
        public LogFoodModel(FoodService FoodService, FoodLogService FoodLogService)
        {
            _foodService = FoodService;
            _foodLogService = FoodLogService;
            
        }

        // methods 

        //public void OnGet(int id, string name)
        //{
        //    FoodLogDay = _foodLogService.GetFoodLogDayById(id);
        //    CurrentMeal = FoodLogDay.Meals.First(m => m.Name == name);
        //}
        public async Task OnGetAsync(int id, string name)
        {
            FoodLogDay = _foodLogService.GetFoodLogDayById(id);
            CurrentMeal = FoodLogDay.Meals.First(m => m.Name == name);

            Foods = await _foodService.GetFoodsAsync();
        }
        // gør, at vi kan få frem, at det er "Morgenmad", der hentydes til



        // NameSearch 
        //public IActionResult OnPostNameSearch()
        //{
        //    Foods = _foodService.NameSearch(SearchString).ToList();
        //    return Page();
        //}
        public async Task<IActionResult> OnPostNameSearchAsync()
        {
            Foods = await _foodService.NameSearchAsync(SearchString);
            return Page();
        }

        // OnPost metode
        //public IActionResult OnPost()
        //{
        //    // 1. Find den valgte food
        //    Models.Food selectedFood = _foodService.GetFoodById(FoodId);

        //    // 2. Lav en "kopi" med brugerens gram
        //    Models.Food foodToLog = new Models.Food
        //    {
        //        Id = selectedFood.Id,
        //        Name = selectedFood.Name,
        //        Kcal = selectedFood.Kcal,
        //        Protein = selectedFood.Protein,
        //        Fat = selectedFood.Fat,
        //        Carbohydrate = selectedFood.Carbohydrate,
        //        Fibre = selectedFood.Fibre,
        //        WeightInGrams = WeightInGramsInput
        //    };
        //      Food = selectedFood; // den fødevare, som brugeren har valgt, skal vises på siden, når den er logget
        //      MealId = CurrentMeal.Id; // det måltid, som brugeren har valgt, skal vises på siden, når den er logget
        //      WeightInGrams = WeightInGramsInput; // den vægt, som brugeren har indtastet, skal vises på siden, når den er logget





        //    // 3. Log maden i det rigtige måltid
        //    _foodLogService.LogFood(FoodLogDay, selectedFoodMeal);


        //    // 4. Gå tilbage til madloggen
        //    return RedirectToPage("/FoodLog/GetFoodLogDay");
        //}



        //---- Metode selv lavet med EF ---------
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    Models.Food selectedFood = await _foodService.GetFoodByIdAsync(FoodId);

        //    Models.Food foodToLog = new Models.Food
        //    {
        //        Id = selectedFood.Id,
        //        Name = selectedFood.Name,
        //        Kcal = selectedFood.Kcal,
        //        Protein = selectedFood.Protein,
        //        Fat = selectedFood.Fat,
        //        Carbohydrate = selectedFood.Carbohydrate,
        //        Fibre = selectedFood.Fibre,
        //        WeightInGrams = WeightInGramsInput
        //    };

        //    _foodLogService.LogFood(FoodLogDay, CurrentMeal, foodToLog);

        //    return RedirectToPage("/FoodLog/GetFoodLogDay");
        //}


    }

}
