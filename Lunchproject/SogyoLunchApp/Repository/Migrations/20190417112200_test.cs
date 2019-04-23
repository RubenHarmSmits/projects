using Microsoft.EntityFrameworkCore.Migrations;

namespace SogyoLunchApp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorien_Winkels_WinkelId",
                table: "Categorien");

            migrationBuilder.DropIndex(
                name: "IX_Categorien_WinkelId",
                table: "Categorien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
