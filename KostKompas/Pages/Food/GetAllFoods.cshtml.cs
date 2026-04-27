using KostKompas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class GetAllFoodsModel : PageModel
    {
        private FoodService _foodService;
        public List<Models.Food> Foods { get; set; }


        public GetAllFoodsModel(FoodService foodService)
        {
           _foodService = foodService;
        }

        public void OnGet()
        {
            Foods = _foodService.GetFoods();
        }
    }
}
