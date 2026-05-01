using KostKompas.Models;
using KostKompas.Pages.Food;

namespace KostKompas.Services
{
    public class FoodService
    {

        private List<Food> foods;

        // constructor 
        public FoodService()
        {
            foods = MockData.MockFood.GetMockFoods();


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
            if (foodToBeDeleted != null)
            {
                foods.Remove(foodToBeDeleted);
            }
            return foodToBeDeleted;



        }

        //NameSearch 
        public IEnumerable<Food> NameSearch(string searchString)

        {
            if (string.IsNullOrEmpty(searchString)) return foods;

            List<Food> nameSearch = foods.FindAll(food => food.Name == searchString);

            return nameSearch;
        }
    }
}

