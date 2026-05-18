using KostKompas.EFDbContext;
using KostKompas.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;


namespace KostKompas.Services
{

    public class FoodLogService
    {
        // Field
        private DbGenericService<FoodLogDay> _foodLogDbService;
        private DbGenericService<Meal> _mealDbService;
        private DbGenericService<FoodMeal> _foodMealDbService;
        private DbGenericService<Food> _foodDbService;
        public List<FoodLogDay> FoodLogDays { get; set; } 
        public List<Meal> Meals { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }
        public List<Food> Foods { get; set; }

        public FoodLogService(DbGenericService<FoodLogDay> foodLogDbService, DbGenericService<Meal> mealDbService, DbGenericService<FoodMeal> foodMealDbService, DbGenericService<Food> foodDbService)
        {
            _foodLogDbService = foodLogDbService;
            _mealDbService = mealDbService;
            _foodMealDbService = foodMealDbService;
            _foodDbService = foodDbService;
            Foods = _foodDbService.GetObjectsAsync().Result.ToList();
            FoodMeals = _foodMealDbService.GetObjectsAsync().Result.ToList();
            Meals = _mealDbService.GetObjectsAsync().Result.ToList();
            FoodLogDays = _foodLogDbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddFoodLogDayAsync(FoodLogDay foodLogDay)
        {
            FoodLogDays.Add(foodLogDay);
            await _foodLogDbService.AddObjectAsync(foodLogDay);
        }

        public async Task<FoodLogDay> GetFoodLogDayByIdAsync(int id)
        {
            FoodLogDay foodLogDay;
            using (var context = new KostKompasDbContext())
            {
                foodLogDay = context.FoodLogDays
                    .Include(fdl => fdl.Meals)
                    .ThenInclude(m => m.FoodMeals)
                    .ThenInclude(fm => fm.Food)
                    .AsNoTracking()
                    .FirstOrDefault(fdl => fdl.Id == id);
            }
            return foodLogDay;
                //foreach (FoodLogDay f in FoodLogDays)
                //{
                //    if (f.Id == id)
                //    {
                //        await _foodLogDbService.GetObjectByIdAsync(id);
                //        f.Meals = _mealDbService.GetObjectsAsync().Result.Where(m => m.FoodLogDayId == f.Id).ToList();
                //        f.Meals.ForEach(m => m.FoodMeals = _foodMealDbService.GetObjectsAsync().Result.Where(fm => fm.MealId == m.Id).ToList());
                //        f.Meals.ForEach(m => m.FoodMeals.ForEach(async fm => fm.Food = await _foodDbService.GetObjectByIdAsync(fm.FoodId)));
                //        return f;
                //    }
                //}
            throw new ArgumentException("Kunne ikke findes");
        }
        public async Task<Meal> GetMealByIdAsync(int id)
        {
            return await _mealDbService.GetObjectByIdAsync(id);
            //foreach (Meal m in Meals)
            //{
            //    if (m.Id == id)
            //    {
            //        return 
            //    }
            //}
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
                //foreach (FoodLogDay f in FoodLogDays)
                //{
                //    if (f.Date == date && f.UserEmail == user.Email)
                //        {
                //        await _foodLogDbService.GetObjectByIdAsync(f.Id);
                //        f.Meals = Meals.Where(m => m.FoodLogDayId == f.Id).ToList();
                //        f.Meals.ForEach(m => m.FoodMeals.AddRange(FoodMeals.Where(fm => fm.MealId == m.Id)));
                //        f.Meals.ForEach(m => m.FoodMeals.ForEach(async fm => fm.Food = await _foodDbService.GetObjectByIdAsync(fm.FoodId)));
                //        return f;
                //    }
                //}
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
