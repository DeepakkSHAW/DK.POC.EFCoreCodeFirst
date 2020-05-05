using Microsoft.EntityFrameworkCore.Migrations;

namespace DK.POC.EFCoreCodeFirst.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TCategories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Notes = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Categoriesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProducts_TCategories_Categoriesid",
                        column: x => x.Categoriesid,
                        principalTable: "TCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProducts_Categoriesid",
                table: "TProducts",
                column: "Categoriesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TProducts");

            migrationBuilder.DropTable(
                name: "TCategories");
        }
    }
}
