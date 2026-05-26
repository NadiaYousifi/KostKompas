using KostKompas.EFDbContext;
using KostKompas.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;


namespace KostKompas.Services
{
    public class FoodLogService
    {
        // Field
        private IDBService<FoodLogDay> _foodLogDbService;
        private IDBService<Meal> _mealDbService;
        private IDBService<FoodMeal> _foodMealDbService;
        public List<FoodLogDay> FoodLogDays { get; set; } 
        public List<Meal> Meals { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }

        public FoodLogService(IDBService<FoodLogDay> foodLogDbService, IDBService<Meal> mealDbService, IDBService<FoodMeal> foodMealDbService)
        {
            _foodLogDbService = foodLogDbService;
            _mealDbService = mealDbService;
            _foodMealDbService = foodMealDbService;
            FoodMeals = _foodMealDbService.GetObjectsAsync().Result.ToList();
            Meals = _mealDbService.GetObjectsAsync().Result.ToList();
            FoodLogDays = _foodLogDbService.GetObjectsAsync().Result.ToList();  
        }

        /// <summary>
        /// Tilføjer en Madlog-dag til listen og databasen. Det er vigtigt at bemærke, at denne metode ikke håndterer oprettelsen af tilknyttede måltider eller fødevarer. Det antages, at disse vil blive håndteret separat, og at FoodLogDay-objektet, der sendes til denne metode, allerede indeholder de nødvendige oplysninger om måltider og fødevarer.
        /// </summary>
        /// <param name="foodLogDay">Den Madlog-dag, der skal tilføjes.</param>
        /// <returns>En opgave, der repræsenterer den asynkrone operation.</returns>
        public async Task AddFoodLogDayAsync(FoodLogDay foodLogDay)
        {
            FoodLogDays.Add(foodLogDay);

            await _foodLogDbService.AddObjectAsync(foodLogDay);
        }


        /// <summary>
        /// Finder et måltid baseret på dets unikke ID. Metoden søger i databasen efter en Meal, der matcher det angivne ID, og inkluderer tilhørende fødevarer i resultatet.
        /// </summary>
        /// <param name="id">ID'et på det måltid, der skal hentes.</param>
        /// <returns>En opgave, der repræsenterer den asynkrone operation, der returnerer det fundne måltid.</returns>
        /// <exception cref="ArgumentException">Hvis det ønskede måltid ikke findes, kastes en ArgumentException med beskeden "Kunne ikke findes".</exception>
        public async Task<Meal> GetMealByIdAsync(int id)
        {
            return await _mealDbService.GetObjectByIdAsync(id);
            throw new ArgumentException("Kunne ikke findes");
        }

        /// <summary>
        /// Finder en Madlog-dag baseret på en given dato og bruger. Metoden søger i databasen efter en FoodLogDay, der matcher den angivne dato og brugerens ID, og inkluderer tilhørende måltider og fødevarer i resultatet.
        /// </summary>
        /// <param name="user">Brugeren, som Madlog-dagen tilhører.</param>
        /// <param name="date">Datoen for den ønskede Madlog-dag.</param>
        /// <returns>En opgave, der repræsenterer den asynkrone operation, der returnerer den fundne Madlog-dag.</returns>
        /// <exception cref="ArgumentException">Hvis den ønskede Madlog-dag ikke findes, kastes en ArgumentException med beskeden "Kunne ikke findes".</exception>
        public async Task<FoodLogDay> GetFoodLogDayByDateAsync(User user, DateTime date)
        {
            FoodLogDay foodLogDay;
            using (var context = new KostKompasDbContext())
            {
                foodLogDay = context.FoodLogDays
                    .Include(fdl => fdl.Meals)
                    .ThenInclude(m => m.FoodMeals)
                    .ThenInclude(fm => fm.Food)
                    .AsNoTracking()
                    .FirstOrDefault(fdl => fdl.Date == date && fdl.UserId == user.Id);
            }
                return foodLogDay;
        }

        /// <summary>
        /// Tilføjer en fødevare til et måltid i en Madlog-dag. Metoden opdaterer både den lokale liste over FoodMeals og databasen ved at tilføje det nye FoodMeal-objekt, der repræsenterer koblingen mellem fødevaren og måltidet.
        /// </summary>
        /// <param name="foodMeal">Den fødevare og det måltid, der skal kobles sammen og tilføjes til Madlog-dagen.</param>
        /// <returns>En opgave, der repræsenterer den asynkrone operation.</returns>
        public async Task LogFoodAsync(FoodMeal foodMeal)
        {
            FoodMeals.Add(foodMeal);
            await _foodMealDbService.AddObjectAsync(foodMeal);
        }
    }
}
