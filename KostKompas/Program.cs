using KostKompas.EFDbContext;
using KostKompas.Models;
using KostKompas.Services;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<KostKompasDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<KostKompasDbContext>();
builder.Services.AddSingleton<FoodService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddScoped<FoodLogService, FoodLogService>();
builder.Services.AddSingleton<DbGenericService<Food, int>, DbGenericService<Food, int>>();
builder.Services.AddSingleton<DbGenericService<User, string>, DbGenericService<User, string>>();
builder.Services.AddScoped<DbGenericService<FoodLogDay, int>, DbGenericService<FoodLogDay, int>>();
builder.Services.AddScoped<DbGenericService<Meal, int>, DbGenericService<Meal, int>>();
builder.Services.AddScoped<DbGenericService<FoodMeal, int>, DbGenericService<FoodMeal, int>>();


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


app.Run(); // starter serveren, og gør at den kan modtage requests
           // det her er min LocalHost-adresse
