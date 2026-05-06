using KostKompas.Models;

namespace KostKompas.Services
{

    public class FoodLogService
    {
        // Field
        private int nextId;
        public List<FoodLogDay> FoodLogDays { get; set; }
        private DbGenericService<FoodLogDay> _dbService;

        public FoodLogService(DbGenericService<FoodLogDay> dbService)
        {
            FoodLogDays = new List<FoodLogDay>();
            _dbService = dbService;
            FoodLogDays = _dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task<FoodLogDay> AddFoodLogDayAsync(FoodLogDay foodLogDay)
        {
            foodLogDay.Id = nextId++;
            FoodLogDays.Add(foodLogDay);
            await _dbService.AddObjectAsync(foodLogDay);
            //_dbService.SaveObjects(foodLogDay);
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
            return await AddFoodLogDayAsync(new FoodLogDay(date));
        }
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

        // metode - tilføjer en fødevare til et bestemt måltid til en bestemt dag
        public void LogFood(FoodLogDay foodLogDay, Meal meal, Food food)
        {
            GetFoodLogDayByIdAsync(foodLogDay.Id).Result.Meals.Find(m => m.Name == meal.Name).AddFood(food);
            //foodLogDay.Meals.Find(m => m.Name == meal.Name).AddFood(food);
            //meal.AddFood(food);

        }
    }


}
