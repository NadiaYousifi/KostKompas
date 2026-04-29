using KostKompas.MockData;
using KostKompas.Models;

namespace KostKompas.Services
{
    public class FoodService
    {
        private List<Food> _foods;

        public FoodService()
        {
            _foods = MockFoods.GetMockFoods();
        
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
