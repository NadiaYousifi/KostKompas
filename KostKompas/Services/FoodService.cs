
using KostKompas.EFDbContext;
using KostKompas.MockData;
using KostKompas.Models;
using Microsoft.EntityFrameworkCore;


namespace KostKompas.Services
{
    public class FoodService 
    {

        // instance fields 
        private List<Food> _foods;
        private DbGenericService<Food> _dbService;

        public FoodService(DbGenericService<Food> dbService)
        {
            _dbService = dbService;
            //_foods = MockFoods.GetMockFoods();
            //_dbService.SaveObjectsAsync(_foods);
            _foods = _dbService.GetObjectsAsync().Result.ToList();
        }


        public async Task AddFoodAsync(Food food)
        {
            _foods.Add(food);
            await _dbService.AddObjectAsync(food);
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            await _dbService.GetObjectsAsync();
            return _foods;
        }


        public async Task UpdateFoodAsync(Food food)
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
                await _dbService.UpdateObjectAsync(food);
            }
        }

        public async Task<Food?> GetFoodByIdAsync(int id)
        {
            foreach (Food f in _foods)
            {
                if (f.Id == id)
                {
                    await _dbService.GetObjectByIdAsync(id);
                    return f;
                }
            }
            throw new ArgumentException("Invalid Id");
        }



        //public Food? DeleteFood(int? foodId)
        //{
        //    Food? foodToBeDeleted = null;
        //    foreach (Food f in _foods)
        //    {
        //        if (f.Id == foodId)
        //        {
        //            foodToBeDeleted = f;
        //            Console.WriteLine(f.Name);
        //            break;
        //        }

        //    }
        //        if (foodToBeDeleted != null)
        //        {
        //            _foods.Remove(foodToBeDeleted);
        //        }
        //    return foodToBeDeleted;
        //}

        public async Task<Food?> DeleteFoodAsync(int? foodId)
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
                _foods.Remove(foodToBeDeleted);
                await _dbService.DeleteObjectAsync(foodToBeDeleted);
            }
            return foodToBeDeleted;
        }





        ////NameSearch 
        //public IEnumerable<Food> NameSearch(string searchString)

        //{
        //    if (string.IsNullOrEmpty(searchString)) return _foods;

        //    List<Food> nameSearch = _foods.FindAll(food => food.Name == searchString);

        //    return nameSearch;
        //}

        // NameSearch med db
        public async Task<List<Food>> NameSearchAsync(string searchString)
        {
            using (var context = new KostKompasDbContext())
           {     
                if (string.IsNullOrEmpty(searchString))
                {
                    return await context.Foods.ToListAsync();
                }

                return await context.Foods
                    .Where(food => food.Name.Contains(searchString))
                    .ToListAsync();
            }
        }

    }
}
