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


    }
}
