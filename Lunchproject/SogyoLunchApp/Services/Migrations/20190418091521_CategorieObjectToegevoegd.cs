using Microsoft.EntityFrameworkCore.Migrations;

namespace SogyoLunchApp.Migrations
{
    public partial class CategorieObjectToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "31a684d8-77c7-4908-a48a-88ce2874fb47");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ad301c98-e0bd-47af-a000-01a6d8419800");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4554aa7e-f324-4356-bd6c-1d0ad713632c", "e551feaf-2b67-4c4a-93c0-1ae497aef0e4", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be6d7bdc-4070-4381-aa95-96a7c1ad384b", "89000517-6a1a-44cd-91c5-58a982d8c7c4", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Producten_CategorieId",
                table: "Producten",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Categorien_CategorieId",
                table: "Producten",
                column: "CategorieId",
                principalTable: "Categorien",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Categorien_CategorieId",
                table: "Producten");

            migrationBuilder.DropIndex(
                name: "IX_Producten_CategorieId",
                table: "Producten");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4554aa7e-f324-4356-bd6c-1d0ad713632c");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "be6d7bdc-4070-4381-aa95-96a7c1ad384b");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31a684d8-77c7-4908-a48a-88ce2874fb47", "07b80bcb-8915-4595-ab95-a8a8d718696b", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad301c98-e0bd-47af-a000-01a6d8419800", "5786dece-8e9b-4ece-b127-c0a52b13cea5", "Admin", null });
        }
    }
}
