using KostKompas.Models;

namespace KostKompas.Services
{
    public class FoodLogService
    {
        public List<FoodLogDay> foodLogDays { get; set; }

        public FoodLogService()
        {
            foodLogDays = new List<FoodLogDay>();
        }

        public void AddFoodLogDay(FoodLogDay foodLogDay)
        {
            foodLogDays.Add(foodLogDay);
        }

        public FoodLogDay GetFoodLogDayById(int id)
        {
            foreach (FoodLogDay f in foodLogDays)
            {
                if (f.Id == id)
                {
                    return f;
                }
            }
            throw new ArgumentException("Kunne ikke findes");
        }



    }


}
