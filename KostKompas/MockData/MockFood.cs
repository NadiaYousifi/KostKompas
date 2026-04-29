using KostKompas.Models;

namespace KostKompas.MockData
{
    public class MockFood
    {
        public static List<Food> Foods = new List<Food>()
        {
            new Food(1,"Tomat", 20, 0.7,0,3.3,1.4),
            new Food(2,"Kylling", 152, 20, 8.7, 0, 0),
            new Food(3, "Broccoli", 35, 3.6, 0.2, 2.1, 3.2)
        };
        public static List<Food> GetMockFoods()
        {
            return Foods;
        }
}
}
