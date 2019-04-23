using Microsoft.EntityFrameworkCore.Migrations;

namespace SogyoLunchApp.Migrations
{
    public partial class relatieProductCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "38e2ec3d-c6e2-4d9b-bbf9-ecbd6fe2f9c1");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9fd0905f-903e-454c-ba91-0b357c6bbf56");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Producten",
                nullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31a684d8-77c7-4908-a48a-88ce2874fb47", "07b80bcb-8915-4595-ab95-a8a8d718696b", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad301c98-e0bd-47af-a000-01a6d8419800", "5786dece-8e9b-4ece-b127-c0a52b13cea5", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "31a684d8-77c7-4908-a48a-88ce2874fb47");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ad301c98-e0bd-47af-a000-01a6d8419800");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Producten");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38e2ec3d-c6e2-4d9b-bbf9-ecbd6fe2f9c1", "614f27a0-02dd-4296-9988-0d936fa8b564", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fd0905f-903e-454c-ba91-0b357c6bbf56", "af91d961-3b7f-4d12-9fe5-c14bfef17898", "Admin", null });
        }
    }
}
