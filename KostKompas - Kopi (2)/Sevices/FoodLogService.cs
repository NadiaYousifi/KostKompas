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

        public FoodLogDay GetFoodLogDayById(int id)
        {
            foreach (FoodLogDay f in foodlogdays)
            {
                if (f.Id == id)
                    return f;
            }
            throw new ArgumentException("Kunne ikke findes");
         
        }
    }


}
