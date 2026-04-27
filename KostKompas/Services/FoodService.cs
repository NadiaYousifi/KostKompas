using KostKompas.Models;

namespace KostKompas.Services
{
    public class FoodService
    {
        private List<Food> _foods;

        public FoodService()
        {
                   _foods = new List<Food>()
        {
            new Food(1,"Tomat", 20, 0.7,0,3.3,1.4),
            new Food(2,"Kylling", 152, 20, 8.7, 0, 0),
            new Food(3, "Broccoli", 35, 3.6, 0.2, 2.1, 3.2)
        };
        }


        public void AddFood(Food food)
        {
            _foods.Add(food);
        }

        public List<Food> GetFoods()
        {
            return _foods;
        }


        public void UpdateFood(Food food)
        {
            if(food != null)
            {
                foreach (Food f in _foods)
                {
                    if(f.Id == food.Id)
                    {
                        f.Name = food.Name;
                        f.Kcal = food.Kcal;
                        f.Protein = food.Kcal;
                        f.Fat = food.Fat;
                        f.CarboHydrate = food.CarboHydrate;
                        f.Fibre = food.Fibre;
                    }
                }
            }
        }

        public Food? GetFoodById(int id)
        {
            foreach (Food f in _foods)
            {     
             if(f.Id == id)
            {
                    return f;
             }    
            }
            throw new ArgumentException("Invalid Id");
        }


        public Food DeleteFood(int? foodId)
        {
            Food foodToBeDeleted = null;
            foreach (Food f in _foods)
            {
                if (f.Id == foodId)
                {
                    foodToBeDeleted = f;
                    Console.WriteLine(f.Name);
                    break;
                }

            }
                if (foodToBeDeleted != null)
                {
                    _foods.Remove(foodToBeDeleted);

                   
                }
            return foodToBeDeleted;
        }


    }
}
