using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SogyoLunchApp.Migrations
{
    public partial class CategorieToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Producten",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorien",
                columns: table => new
                {
                    CategorieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategorieNaam = table.Column<string>(nullable: true),
                    WinkelId = table.Column<int>(nullable: false),
                    VolgordeNummer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorien", x => x.CategorieId);
                    table.ForeignKey(
                        name: "FK_Categorien_Winkels_WinkelId",
                        column: x => x.WinkelId,
                        principalTable: "Winkels",
                        principalColumn: "WinkelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producten_CategorieId",
                table: "Producten",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorien_WinkelId",
                table: "Categorien",
                column: "WinkelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producten_Categorien_CategorieId",
                table: "Producten",
                column: "CategorieId",
                principalTable: "Categorien",
                principalColumn: "CategorieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producten_Categorien_CategorieId",
                table: "Producten");

            migrationBuilder.DropTable(
                name: "Categorien");

            migrationBuilder.DropIndex(
                name: "IX_Producten_CategorieId",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Producten");
        }
    }
}
