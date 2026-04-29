using KostKompas.Models;
using Microsoft.AspNetCore.Identity;

namespace KostKompas.MockData
{
    public class MockFood
    {

        // metode
        public static List<Food> GetMockFoods()
        {
            return foods;
        }
        // metode

        private static List<Food> foods = new List<Food>()
        {
           new Models.Food(1, "Tomat", 20, 0.7, 0, 3.3, 1.4),
            new Models.Food(2, "Kylling", 152, 20, 8.7, 0, 0),
            new Models.Food(3, "Broccoli", 35, 3.6, 0.2, 2.1, 3.2)
        };
    }
}

