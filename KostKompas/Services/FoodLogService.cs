using KostKompas.Models;

namespace KostKompas.Services
{

    public class FoodLogService
    {
        // instance field
        private int nextId;
        public List<FoodLogDay> FoodLogDays { get; set; }


        public FoodLogService()
        {
            FoodLogDays = new List<FoodLogDay>();
        }


        // AddFoodLogDay - metode
        public FoodLogDay AddFoodLogDay(FoodLogDay foodLogDay)
        {
            foodLogDay.Id = nextId++;
            FoodLogDays.Add(foodLogDay);
            return foodLogDay;
        }
        // metoden gør, at jeg kan finde den dag, jeg gerne vil finde


        // GetFoodLoogDayById - metode
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
        // finder den rette dag ved at søge efter det rette ID




        // Søg efter dato metode
        public FoodLogDay GetFoodLogDayByDate(DateTime date)
        {
            foreach (FoodLogDay f in FoodLogDays)
            {
                if (f.Date == date)
                    return f;
            }
            return AddFoodLogDay(new FoodLogDay());
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

        // LogFood - metoden
        public void LogFood(FoodLogDay foodLogDay, Meal meal, Food food)
        {
            GetFoodLogDayById(foodLogDay.Id).Meals.Find(m => m.Name == meal.Name).AddFood(food);
            //meal.AddFood(food);
            
        }
        // metoden tilføjer fødevaren til det rette måltid på den rette dag 
    }


}
