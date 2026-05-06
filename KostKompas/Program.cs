using KostKompas.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using KostKompas.Data;
using Microsoft.EntityFrameworkCore;
using KostKompas.Data;
using KostKompas.MockData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KostKompasDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<FoodService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<FoodLogService, FoodLogService>();
builder.Services.AddSingleton<ChatService, ChatService>();


builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
    cookieOptions.LoginPath = "/LogIn/LogInPage";

});
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizeFolder("/Food"); //

});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // sørgr for at browseren bruger HHTP
app.UseStaticFiles(); // gør at browseren kan hente CSS, javascript og billeder fra wwwroot

app.UseRouting(); // gør serveren klar til at finde den rette razor page ud fra URL'en

app.UseAuthorization(); // sørger for at brugeren er logget ind, før den får adgang til siderne i Food-mappen

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<KostKompasDbContext>();

    // Seed users
    if (!context.Users.Any())
    {
        var mockUsers = KostKompas.MockData.MockUsers.GetMockUsers();

        foreach (var user in mockUsers)
        {
            context.Users.Add(new KostKompas.Models.User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                KcalGoal = user.KcalGoal,
                ProteinGoal = user.ProteinGoal,
                CarbohydrateGoal = user.CarbohydrateGoal,
                FatGoal = user.FatGoal,
                FibreGoal = user.FibreGoal
            });
        }

        context.SaveChanges();
    }

    // Seed foods
    if (!context.Foods.Any())
    {
        var adminUser = context.Users.First();

        var mockFoods = KostKompas.MockData.MockFoods.GetMockFoods();

        foreach (var food in mockFoods)
        {
            context.Foods.Add(new KostKompas.Models.Food
            {
                User_id = adminUser.Id,
                Name = food.Name,
                Kcal = food.Kcal,
                Protein = food.Protein,
                Fat = food.Fat,
                Carbohydrate = food.Carbohydrate,
                Fibre = food.Fibre,
                WeightInGrams = food.WeightInGrams
            });
        }

        context.SaveChanges();
    }
}





app.Run(); // starter serveren, og gør at den kan modtage requests
           // det her er min LocalHost-adresse
