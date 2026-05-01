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
            if (food != null)
            {
                foreach (Food f in _foods)
                {
                    if (f.Id == food.Id)
                    {
                        f.Name = food.Name;
                        f.Kcal = food.Kcal;
                        f.Protein = food.Protein;
                        f.Fat = food.Fat;
                        f.Carbohydrate = food.Carbohydrate;
                        f.Fibre = food.Fibre;
                    }
                }
            }
        }
        public Food GetFoodById(int id)
        {
            foreach (Food f in _foods)
            {
                if (id == f.Id)
                {
                    return f;
                }
            }
            throw new ArgumentException("The given Id doesn't exist");
        }
        public Food DeleteFood(int? foodId)
        {
            Food foodToBeDeleted = null;
            foreach (Food f in _foods)
            {
                if (f.Id == foodId)
                {
                    foodToBeDeleted = f;
                    break;
                }
            }
            if (foodToBeDeleted != null)
            {
                _foods.Remove(foodToBeDeleted);
            }
            return foodToBeDeleted;
        }
        public IEnumerable<Food> NameSearch(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return _foods;
            List<Food> nameSearch = _foods.FindAll(food => food.Name.ToLower().Equals(searchString.ToLower()));
            return nameSearch;
        }
    }
}
