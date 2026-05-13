using KostKompas.EFDbContext;
using KostKompas.Models;
using KostKompas.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<KostKompasDbContext>();
builder.Services.AddSingleton<FoodService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddScoped<FoodLogService, FoodLogService>();
builder.Services.AddSingleton<DbGenericService<Food, int>, DbGenericService<Food, int>>();
builder.Services.AddSingleton<DbGenericService<User, string>, DbGenericService<User, string>>();
builder.Services.AddScoped<DbGenericService<Meal, int>, DbGenericService<Meal, int>>();
builder.Services.AddScoped<DbGenericService<FoodMeal, int>, DbGenericService<FoodMeal, int>>();
builder.Services.AddScoped<DbGenericService<FoodLogDay, int>, DbGenericService<FoodLogDay, int>>();

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
    options.Conventions.AuthorizeFolder("/Food");

});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
