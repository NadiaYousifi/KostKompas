using KostKompas.Models;

namespace KostKompas.Sevices
{
    public class FoodLogService
    {
        // property 
        List<FoodLogDay> foodlogdays {  get; set; }

        // constructor
        public FoodLogService()
        {
            foodlogdays = new List<FoodLogDay>();
        }


        // Add metode
        public void AddFoodLogDay(FoodLogDay foodlogday)
        {
            foodlogdays.Add(foodlogday);
        }


        // GetById
        public FoodLogDay GetFoodLogDayById(int id)
        {
            foreach (FoodLogDay f in foodlogdays)
            {
                if (f.Id == id)
                    return f;
            }
            throw new ArgumentException("Kunne ikke findes");
         
        }

        // Søg efter dato metode
        public FoodLogDay GetFoodLogDayByDate(DateTime date)
        {
            foreach (FoodLogDay f in foodlogdays)
            {
                if (f.Date == date)
                    return f;
            }
            return new FoodLogDay();
        }

        // metode - tilføjer en fødevare til et bestemt måltid til en bestemt dag
        public void LogFood(DateTime date, string mealName, Food food)
        {
            FoodLogDay day = GetFoodLogDayByDate((DateTime)date);
            if (day == null)
            {
                day = new FoodLogDay();
                day.Date = date.Date;
                foodlogdays.Add(day);
                return;
            }
            Meal meal = day.Meals.FirstOrDefault(m => m.Name == mealName);

            if (meal != null)
            {
                meal.AddFood(food);
            }
        }
     
    }


}
