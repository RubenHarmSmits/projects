using Microsoft.EntityFrameworkCore.Migrations;

namespace SogyoLunchApp.Migrations
{
    public partial class CategorieHeeftWinkel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4554aa7e-f324-4356-bd6c-1d0ad713632c");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "be6d7bdc-4070-4381-aa95-96a7c1ad384b");

            migrationBuilder.AddColumn<int>(
                name: "WinkelId",
                table: "Categorien",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8982c385-ecc6-4018-bcf6-5014c9821785", "7870e89a-df1f-471f-a3b4-dee65fea04b9", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bbf9cd5-5f71-4b78-804f-2d4d41473d98", "980ce0c0-3e37-4a15-8d5b-45e7e197cd39", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Categorien_WinkelId",
                table: "Categorien",
                column: "WinkelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorien_Winkels_WinkelId",
                table: "Categorien",
                column: "WinkelId",
                principalTable: "Winkels",
                principalColumn: "WinkelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorien_Winkels_WinkelId",
                table: "Categorien");

            migrationBuilder.DropIndex(
                name: "IX_Categorien_WinkelId",
                table: "Categorien");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5bbf9cd5-5f71-4b78-804f-2d4d41473d98");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8982c385-ecc6-4018-bcf6-5014c9821785");

            migrationBuilder.DropColumn(
                name: "WinkelId",
                table: "Categorien");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4554aa7e-f324-4356-bd6c-1d0ad713632c", "e551feaf-2b67-4c4a-93c0-1ae497aef0e4", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be6d7bdc-4070-4381-aa95-96a7c1ad384b", "89000517-6a1a-44cd-91c5-58a982d8c7c4", "Admin", null });
        }
    }
}
