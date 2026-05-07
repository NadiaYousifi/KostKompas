using KostKompas.Models;


namespace KostKompas.Services
{

    public class FoodLogService
    {
        // Field
        private int nextId;
        public List<FoodLogDay> FoodLogDays { get; set; }

        public FoodLogService()
        {
            FoodLogDays = new List<FoodLogDay>();
        }

        public FoodLogDay AddFoodLogDay(FoodLogDay foodLogDay)
        {
            foodLogDay.Id = nextId++;
            FoodLogDays.Add(foodLogDay);
            return foodLogDay;
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
            throw new ArgumentException("Kunne ikke findes");
        }

        // Søg efter dato metode
        public FoodLogDay GetFoodLogDayByDate(DateTime date)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Date == date)
                    return f;
            }
            return AddFoodLogDay(new FoodLogDay(date));
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
        public void LogFood(FoodLogDay foodLogDay, FoodMeal foodMeal)
        {
            GetFoodLogDayById(foodLogDay.Id).Meals.Find(m => m.Id == foodMeal.Meal_id).FoodMeals.Add(foodMeal);  
            //foodLogDay.Meals.Find(m => m.Name == meal.Name).AddFood(food);
            //meal.AddFood(food);

        }
    }


}
