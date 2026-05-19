using KostKompas.EFDbContext;
using KostKompas.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;


namespace KostKompas.Services
{
    public class FoodLogService
    {
        private DbGenericService<FoodLogDay> _foodLogDbService;
        private DbGenericService<Meal> _mealDbService;
        private DbGenericService<FoodMeal> _foodMealDbService;
        private DbGenericService<Food> _foodDbService;
        public List<FoodLogDay> FoodLogDays { get; set; } 
        public List<Meal> Meals { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }
        public List<Food> Foods { get; set; }

        public FoodLogService(DbGenericService<FoodLogDay> foodLogDbService, DbGenericService<Meal> mealDbService, DbGenericService<FoodMeal> foodMealDbService, DbGenericService<Food> foodDbService)
        {
            _foodLogDbService = foodLogDbService;
            _mealDbService = mealDbService;
            _foodMealDbService = foodMealDbService;
            _foodDbService = foodDbService;
            Foods = _foodDbService.GetObjectsAsync().Result.ToList();
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
        /// Finder en Madlog-dag baseret på dens unikke ID. Metoden søger i databasen efter en FoodLogDay, der matcher det angivne ID, og inkluderer tilhørende måltider og fødevarer i resultatet.
        /// </summary>
        /// <param name="id">ID'et på den Madlog-dag, der skal hentes.</param>
        /// <returns>En opgave, der repræsenterer den asynkrone operation, der returnerer den fundne Madlog-dag.</returns>
        /// <exception cref="ArgumentException">Hvis den ønskede Madlog-dag ikke findes, kastes en ArgumentException med beskeden "Kunne ikke findes".</exception>
        public async Task<FoodLogDay> GetFoodLogDayByIdAsync(int id)
        {
            FoodLogDay foodLogDay;
            using (var context = new KostKompasDbContext())
            {
                foodLogDay = context.FoodLogDays
                    .Include(fdl => fdl.Meals)
                    .ThenInclude(m => m.FoodMeals)
                    .ThenInclude(fm => fm.Food)
                    .AsNoTracking()
                    .FirstOrDefault(fdl => fdl.Id == id);
            }
            return foodLogDay;
                //foreach (FoodLogDay f in FoodLogDays)
                //{
                //    if (f.Id == id)
                //    {
                //        await _foodLogDbService.GetObjectByIdAsync(id);
                //        f.Meals = _mealDbService.GetObjectsAsync().Result.Where(m => m.FoodLogDayId == f.Id).ToList();
                //        f.Meals.ForEach(m => m.FoodMeals = _foodMealDbService.GetObjectsAsync().Result.Where(fm => fm.MealId == m.Id).ToList());
                //        f.Meals.ForEach(m => m.FoodMeals.ForEach(async fm => fm.Food = await _foodDbService.GetObjectByIdAsync(fm.FoodId)));
                //        return f;
                //    }
                //}
            throw new ArgumentException("Kunne ikke findes");
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
            //foreach (Meal m in Meals)
            //{
            //    if (m.Id == id)
            //    {
            //        return 
            //    }
            //}
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
                //foreach (FoodLogDay f in FoodLogDays)
                //{
                //    if (f.Date == date && f.UserEmail == user.Email)
                //        {
                //        await _foodLogDbService.GetObjectByIdAsync(f.Id);
                //        f.Meals = Meals.Where(m => m.FoodLogDayId == f.Id).ToList();
                //        f.Meals.ForEach(m => m.FoodMeals.AddRange(FoodMeals.Where(fm => fm.MealId == m.Id)));
                //        f.Meals.ForEach(m => m.FoodMeals.ForEach(async fm => fm.Food = await _foodDbService.GetObjectByIdAsync(fm.FoodId)));
                //        return f;
                //    }
                //}
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
