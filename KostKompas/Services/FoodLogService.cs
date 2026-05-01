using KostKompas.Models;

namespace KostKompas.Services
{
    public class FoodLogService
    {
        public List<FoodLogDay> FoodLogDays { get; set; }

        public FoodLogService()
        {
            FoodLogDays = new List<FoodLogDay>();
        }
        public void AddFoodLogDay(FoodLogDay foodLogDay)
        {
            FoodLogDays.Add(foodLogDay);
        }
        public FoodLogDay GetFoodLogDayById(int id)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Id == id)
                {
                 return f;   
                }
            }
            throw new ArgumentException("Den givne Id findes ikke");
        }
        public FoodLogDay GetFoodLogDayByDate(DateTime date)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Date == date)
                {
                    return f;
                }
            }
            return new FoodLogDay();
        }
        public void LogFood(DateTime date, string mealName, Food food)
        {
            FoodLogDay day = GetFoodLogDayByDate((DateTime) date);
            if (day == null)
            {
                return;   
            }
            Meal meal = day.Meals.FirstOrDefault(m  => m.Name == mealName);
            if (meal != null)
            {
                meal.AddFood(food);
            }
        }
    }
}
