using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SogyoLunchApp.Migrations
{
    public partial class CategorieToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "51916355-944c-4d52-8641-6598d6983745");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d0d5e76c-5632-4984-802f-c24e77c79eb6");

            migrationBuilder.CreateTable(
                name: "Categorien",
                columns: table => new
                {
                    CategorieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategorieNaam = table.Column<string>(nullable: true),
                    VolgordeNummer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorien", x => x.CategorieId);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38e2ec3d-c6e2-4d9b-bbf9-ecbd6fe2f9c1", "614f27a0-02dd-4296-9988-0d936fa8b564", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fd0905f-903e-454c-ba91-0b357c6bbf56", "af91d961-3b7f-4d12-9fe5-c14bfef17898", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorien");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "38e2ec3d-c6e2-4d9b-bbf9-ecbd6fe2f9c1");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9fd0905f-903e-454c-ba91-0b357c6bbf56");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51916355-944c-4d52-8641-6598d6983745", "65fe010d-9573-46e3-9980-329f90291437", "User", null });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0d5e76c-5632-4984-802f-c24e77c79eb6", "1c4132cc-6ef2-44fb-84f8-322dcc990cd7", "Admin", null });
        }
    }
}
