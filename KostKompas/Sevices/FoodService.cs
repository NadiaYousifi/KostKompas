using KostKompas.Models;

namespace KostKompas.Sevices
{
    public class FoodService
    {

        private List<Food> foods;

        // constructor 
        public FoodService() 
        {
            foods = new List<Food>()
            {
            new Models.Food(1, "Tomat", 20, 0.7, 0, 3.3, 1.4),
            new Models.Food(2, "Kylling", 152, 20, 8.7, 0, 0),
            new Models.Food(3, "Broccoli", 35, 3.6, 0.2, 2.1, 3.2)
            };
        }




        // Add method
        public void AddFood(Food food)
        {
            foods.Add(food);
        }

        // Get method
        public List<Food> GetFoods()
        {
            return foods;
        }



        // Update method
        public void UpdateFood(Food food)
        {
            if (food != null)
            {
                foreach (Food f in foods)
                {
                    if (f.Id == food.Id)
                    {
                        f.Name = food.Name;
                        f.Kcal = food.Kcal;
                        f.Protein = food.Protein;
                        f.Carbohydrate = food.Carbohydrate;

                    }
                }
            }
        }



        // GetById
        public Food? GetFood(int id)
        {
            foreach (Food f in foods)
            {
                if (f.Id == id)
                    return f;
            }
            throw new ArgumentException("Fødevare findes ikke");
        }


        // Delete method 
        public Food DeleteFood(int? id)
        {
            Food foodToBeDeleted = null;
            foreach (Food food in foods)
            {
                if (food.Id == id)
                {
                    foodToBeDeleted = food;
                    break;
                }

            }
            return foodToBeDeleted;


         
        }
    }
}
