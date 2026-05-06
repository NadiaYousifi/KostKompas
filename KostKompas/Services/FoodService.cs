using KostKompas.Data;
using KostKompas.MockData;
using KostKompas.Models;
using Microsoft.EntityFrameworkCore;

namespace KostKompas.Services
{
    public class FoodService
    {
        private readonly KostKompasDbContext _context;

        //public FoodService()
        //{
        //    _foods = MockFoods.GetMockFoods();

        //}
        public FoodService(KostKompasDbContext context)
        {
            _context = context;
        }


        //public void AddFood(Food food)
        //{
        //    _foods.Add(food);
        //}

        public async Task AddFoodAsync(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
        }

        //public List<Food> GetFoods()
        //{
        //    return _foods;
        //}

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _context.Foods.ToListAsync();
        }


        //public void UpdateFood(Food food)
        //{
        //    if(food != null)
        //    {
        //        foreach (Food f in _foods)
        //        {
        //            if(f.Id == food.Id)
        //            {
        //                f.Name = food.Name;
        //                f.Kcal = food.Kcal;
        //                f.Protein = food.Kcal;
        //                f.Fat = food.Fat;
        //                f.Carbohydrate = food.Carbohydrate;
        //                f.Fibre = food.Fibre;
        //            }
        //        }
        //    }
        //}

        // Update metode med db
        public async Task UpdateFoodAsync(Food food)
        {
            if (food != null)
            {
                _context.Foods.Update(food);
                await _context.SaveChangesAsync();
            }
        }


        //public Food? GetFoodById(int id)
        //{
        //    foreach (Food f in _foods)
        //    {     
        //     if(f.Id == id)
        //    {
        //            return f;
        //     }    
        //    }
        //    throw new ArgumentException("Invalid Id");
        //}

        // getbyid metode med db
        public async Task<Food?> GetFoodByIdAsync(int id)
        {
            return await _context.Foods.FirstOrDefaultAsync(f => f.Id == id);
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

        // delete metode med db
        public async Task<Food?> DeleteFoodAsync(int foodId)
        {
            Food? foodToBeDeleted = await GetFoodByIdAsync(foodId);

            if (foodToBeDeleted != null)
            {
                _context.Foods.Remove(foodToBeDeleted);
                await _context.SaveChangesAsync();
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
            if (string.IsNullOrEmpty(searchString))
            {
                return await _context.Foods.ToListAsync();
            }

            return await _context.Foods
                .Where(food => food.Name.Contains(searchString))
                .ToListAsync();
        }

    }
}
