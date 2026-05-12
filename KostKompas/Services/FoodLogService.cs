using KostKompas.Models;

namespace KostKompas.Services
{

    public class FoodLogService
    {
        // Field
        private DbGenericService<FoodLogDay, int> _foodLogDbService;
        private DbGenericService<Meal, int> _mealDbService;
        private DbGenericService<FoodMeal, int> _foodMealDbService;
        public List<FoodLogDay> FoodLogDays { get; set; } 
        public List<Meal> Meals { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }

        public FoodLogService(DbGenericService<FoodLogDay, int> foodLogDbService, DbGenericService<Meal, int> mealDbService, DbGenericService<FoodMeal, int> foodMealDbService)
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
            Meals.AddRange(foodLogDay.Meals);
            await _foodLogDbService.AddObjectAsync(foodLogDay);
            // await _mealDbService.SaveObjectsAsync(Meals);
        }

        public async Task<FoodLogDay> GetFoodLogDayByIdAsync(int id)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Id == id)
                {
                    await _foodLogDbService.GetObjectByIdAsync(id);
                    f.Meals = _mealDbService.GetObjectsAsync().Result.Where(m => m.FoodLogDayId == f.Id ).ToList();
                    f.Meals.ForEach(m => m.FoodMeals = _foodMealDbService.GetObjectsAsync().Result.Where(fm => fm.MealId == m.Id).ToList());
                    return f;
                }
            }
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
        public async Task<Meal> GetMealByNameAsync(string name)
        {
            foreach (Meal m in Meals)
            {
                if (m.Name == name)
                {
                    return await _mealDbService.GetObjectByIdAsync(m.Id);
                }
            }
            throw new ArgumentException("Kunne ikke findes");
        }

        // Søg efter dato metode
        public async Task<FoodLogDay> GetFoodLogDayByDateAsync(User user, DateTime date)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Date == date && f.UserEmail == user.Email)
                    {                    
                    //await _foodLogDbService.GetObjectByIdAsync(f.Id);
                    //f.Meals = Meals.Where(m => m.FoodLogDayId == f.Id).ToList();
                    //f.Meals.ForEach(m => m.FoodMeals.AddRange(FoodMeals.Where(fm => fm.MealId == m.Id)));
                    //return f;
                    return await _foodLogDbService.GetObjectByIdAsync(f.Id);
                }
            }
            return null;
        } 
        // metode - tilføjer en fødevare til et bestemt måltid til en bestemt dag
        public async Task LogFoodAsync(FoodMeal foodMeal)
        {
            FoodMeals.Add(foodMeal);
            await _foodMealDbService.AddObjectAsync(foodMeal);
        }
    }
}
