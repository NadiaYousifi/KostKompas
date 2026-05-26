using KostKompas.MockData;
using KostKompas.Models;
using KostKompas.Services;

namespace KostKompasTest
{
    [TestClass]
    public sealed class FoodServiceTest
    {
        //Dummy DBservice
        private IDBService<Food> _foodDb;
        private FoodService _foodService;
        private List<Food> _foods;
        public FoodServiceTest() 
        {
        }
        private void Arrange()
        {
            MockFoods.GenerateTestIds();
            _foods = MockFoods.GetMockFoods();
            _foodDb = new MockDbService<Food>(_foods);
            _foodService = new FoodService(_foodDb);
        }
        [TestMethod]
        public void TestGetFoodsAsync_ReturnMockFoods()
        {
            // Arrange
            Arrange();
            List<Food> ExpectedResult = MockFoods.GetMockFoods();
            // Act
            List<Food> ActualResult = _foodService.GetFoodsAsync().Result;
            // Assert
            Assert.AreEqual(ExpectedResult.Intersect(ActualResult).Count(), ActualResult.Count());
        }

        [TestMethod]
        public void TestAddFood_ValidFood()
        {
            // Arrange
            Arrange();
            Food testFood = new Food()
            {
                Name = "Test",
                Kcal = 200,
                Protein = 200,
                Fat = 200,
                Carbohydrate = 200,
                Fibre = 200,
            };

            // Act
            _foodService.AddFoodAsync(testFood);

            // Assert
            Assert.Contains(testFood, _foods);
        }

        [TestMethod]
        public async Task TestGetFoodByIdAsync_ReturnIndex_4()
        {
            // Arrange
            Arrange();
            await _foodService.GetFoodsAsync();
            int ExpectedResult = 4;
            // Act
            Food ActualResult = await _foodService.GetFoodByIdAsync(4);
            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult.Id);
        }

        [TestMethod]
        public async Task TestGetFoodByIdAsync_ThrowsException()
        {
            // Arrange
            Arrange();
            // Act & Assert
            await Assert.ThrowsExactlyAsync<ArgumentException>( async () => { await _foodService.GetFoodByIdAsync(-12); }, "Invalid Id");
        }

        [TestMethod]
        public async Task TestUpdateFoodAsync_ChangeProtein_100()
        {
            // Arrange
            Arrange();

            double ExpectedResult = 100;
            Food food = new Food() { Id = 2, Name = "Broccoli", Kcal = 35, Protein = 100, Fat = 0.2, Carbohydrate = 2.1, Fibre = 3.2 };
            // Act
            await _foodService.UpdateFoodAsync(food);
            Food ActualResult = await _foodService.GetFoodByIdAsync(2);

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult.Protein);
        }
        [TestMethod]
        public void TestDeleteFoodAsync_Remove_Id2()
        {
            // Arrange
            Arrange();
            Food food = new Food() { Id = 2, Name = "Broccoli", Kcal = 35, Protein = 100, Fat = 0.2, Carbohydrate = 2.1, Fibre = 3.2 };
            List<Food> ExpectedResult = _foodService.GetFoodsAsync().Result;
            // Act

            Food DeletionResult = _foodService.DeleteFoodAsync(2).Result;
            ExpectedResult.Remove(DeletionResult);
            List<Food> ActualResult = _foodService.GetFoodsAsync().Result;
            // Assert
            Assert.IsTrue(!ExpectedResult.Contains(DeletionResult) && !ActualResult.Contains(DeletionResult));
        }
    }
}
