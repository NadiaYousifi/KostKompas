using KostKompas.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KostKompas.Pages.Food
{
    public class GetAllFoodsModel : PageModel
    {
        // instance fields 
        private FoodService _foodService;

        // property
        public List<Models.Food> foods { get; private set; }

        // constructor
        public GetAllFoodsModel(FoodService foodService)
        {
            _foodService = foodService;
        }




        public void OnGet()
        {
            foods = _foodService.GetFoods();
        }
    }
}
