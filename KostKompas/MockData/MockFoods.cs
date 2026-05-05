using KostKompas.Models;

namespace KostKompas.MockData
{
    public class MockFoods
    {

        private static List<Food> foods = new List<Food>() 
        {
            new Food(1,"Tomat", 20, 0.7,0,3.3,1.4),
            new Food(2,"Kylling", 152, 20, 8.7, 0, 0),
            new Food(3, "Broccoli", 35, 3.6, 0.2, 2.1, 3.2),
            new Food(4, "Rugbrød", 199, 5, 1.5, 38, 9),
            new Food(5, "Æg", 137, 12, 9, 1, 0),
            new Food(6, "Purløg", 104, 2, 0.6, 4, 2.4),
            new Food(7, "Ris", 358, 9, 3, 76, 4.2),
            new Food(8, "Mayonnaise", 715, 0.6, 79, 0, 0)

        };

        public static List<Food> GetMockFoods()
        {
            return foods;
        }
    }
}
