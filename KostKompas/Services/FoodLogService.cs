using KostKompas.EFDbContext;
using KostKompas.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;


namespace KostKompas.Services
{

    public class FoodLogService
    {
        // Field
        private IService<FoodLogDay> _foodLogDbService;
        private IService<Meal> _mealDbService;
        private IService<FoodMeal> _foodMealDbService;
        public List<FoodLogDay> FoodLogDays { get; set; } 
        public List<Meal> Meals { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }

        public FoodLogService(IService<FoodLogDay> foodLogDbService, IService<Meal> mealDbService, IService<FoodMeal> foodMealDbService)
        {
            _foodLogDbService = foodLogDbService;
            _mealDbService = mealDbService;
            _foodMealDbService = foodMealDbService;
            FoodMeals = _foodMealDbService.GetObjectsAsync().Result.ToList();
            Meals = _mealDbService.GetObjectsAsync().Result.ToList();
            FoodLogDays = _foodLogDbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddFoodLogDayAsync(FoodLogDay foodLogDay)
        {
            FoodLogDays.Add(foodLogDay);
            await _foodLogDbService.AddObjectAsync(foodLogDay);
        }

        public async Task<Meal> GetMealByIdAsync(int id)
        {
            return await _mealDbService.GetObjectByIdAsync(id);
            throw new ArgumentException("Kunne ikke findes");
        }


        // Søg efter dato metode
        public async Task<FoodLogDay> GetFoodLogDayByDateAsync(User user, DateTime date)
        {
            FoodLogDay foodLogDay;
            using (var context = new KostKompasDbContext())
            {
                foodLogDay = context.FoodLogDays
                    .Include(fdl => fdl.Meals)
                    .ThenInclude(m => m.FoodMeals)
                    .ThenInclude(fm => fm.Food)
                    .AsNoTracking()
                    .FirstOrDefault(fdl => fdl.Date == date && fdl.UserId == user.Id);
            }
                return foodLogDay;
        } 
        // metode - tilføjer en fødevare til et bestemt måltid til en bestemt dag
        public async Task LogFoodAsync(FoodMeal foodMeal)
        {
            FoodMeals.Add(foodMeal);
            await _foodMealDbService.AddObjectAsync(foodMeal);
        }
    }
}
