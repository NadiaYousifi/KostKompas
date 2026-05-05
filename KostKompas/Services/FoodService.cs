using KostKompas.MockData;
using KostKompas.Models;

namespace KostKompas.Services
{
    public class FoodService
    {
        private List<Food> _foods;
        private DBServiceFood _dBServiceFood;

        public FoodService( DBServiceFood dBServiceFood)
        {
            //_foods = MockFoods.GetMockFoods();
            _dBServiceFood = dBServiceFood;
            //foreach (var food in _foods)
            //{
            //    dBServiceFood.Create(food);   
            //}
            _foods = dBServiceFood.GetAllFoods();


        }


        public void AddFood(Food food)
        {
            _foods.Add(food);
            _dBServiceFood.Create(food);
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
                        f.Carbohydrate = food.Carbohydrate;
                        f.Fibre = food.Fibre;
                    }
                }
                _dBServiceFood.Update(food);
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


        public Food? DeleteFood(int foodId)
        {
            Food? foodToBeDeleted = null;
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
                    _dBServiceFood.Delete(foodId);
                    _foods.Remove(foodToBeDeleted);
                }
            return foodToBeDeleted;
        }
        public IEnumerable<Food> NameSearch(string searchString)

        {
            if (string.IsNullOrEmpty(searchString)) return _foods;

            List<Food> nameSearch = _foods.FindAll(food => food.Name == searchString);

            return nameSearch;
        }

    }
}
