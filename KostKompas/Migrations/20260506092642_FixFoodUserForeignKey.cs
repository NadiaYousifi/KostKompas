using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KostKompas.Migrations
{
    /// <inheritdoc />
    public partial class FixFoodUserForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_userId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_userId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Foods");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_User_id",
                table: "Foods",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_User_id",
                table: "Foods",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Users_User_id",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_User_id",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_userId",
                table: "Foods",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Users_userId",
                table: "Foods",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
