using KostKompas.Models;
using System.Threading.Tasks;

namespace KostKompas.Services
{

    public class FoodLogService
    {
        // Field
        private int nextId;
        public List<FoodLogDay> FoodLogDays { get; set; }

        private DbService<FoodLogDay> _dbService;

        public FoodLogService(DbService<FoodLogDay> dbService)
        {
            FoodLogDays = new List<FoodLogDay>();
            _dbService = dbService;
            _dbService.SaveObjectsAsync(FoodLogDays);
            FoodLogDays = dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task<FoodLogDay> AddFoodLogDayAsync(FoodLogDay foodLogDay)
        {
            foodLogDay.Id = nextId++;
            FoodLogDays.Add(foodLogDay);
            await _dbService.AddObjectAsync(foodLogDay);
            return foodLogDay;
        }

        public async Task<FoodLogDay> GetFoodLogDayByIdAsync(int id)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Id == id)
                {
                    await _dbService.GetObjectByIdAsync(id);
                    return f;
                }
            }
            throw new ArgumentException("Kunne ikke findes");
        }

        // Søg efter dato metode
        public async Task<FoodLogDay> GetFoodLogDayByDateAsync(DateTime date)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Date == date)
                    await _dbService.GetObjectByDateAsync(date);
                return f;
            }

            return await AddFoodLogDayAsync(new FoodLogDay());
        }
        // metode - tilføjer en fødevare til et bestemt måltid til en bestemt dag
        //public void LogFood(DateTime date, string mealName, Food food)
        //{
        //    FoodLogDay day = GetFoodLogDayByDate((DateTime)date);
        //    if (day == null)
        //    {
        //        day = new FoodLogDay();
        //        day.Date = date.Date;
        //        FoodLogDays.Add(day);
        //        return;
        //    }
        //    Meal meal = day.Meals.FirstOrDefault(m => m.Name == mealName);

        //    if (meal != null)
        //    {
        //        meal.AddFood(food);
        //    }
        //}

        public void LogFood(FoodLogDay foodLogDay, FoodMeal foodMeal)
        {
            GetFoodLogDayByIdAsync(foodLogDay.Id).Result.Meals.Find(m => m.Id == foodMeal.MealId).FoodMeals.Add(foodMeal);
           
        }


    }
}
