using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KostKompas.Migrations
{
    /// <inheritdoc />
    public partial class KostKompasDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodLogDays_Meals_MealId",
                table: "FoodLogDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_MealId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_FoodLogDays_MealId",
                table: "FoodLogDays");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "WeightInGrams",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "FoodLogDays");

            migrationBuilder.CreateTable(
                name: "FoodMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    WeightInGrams = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMeals_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeals_FoodId",
                table: "FoodMeals",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeals_MealId",
                table: "FoodMeals",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMeals");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WeightInGrams",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "FoodLogDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MealId",
                table: "Foods",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodLogDays_MealId",
                table: "FoodLogDays",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodLogDays_Meals_MealId",
                table: "FoodLogDays",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }
    }
}
