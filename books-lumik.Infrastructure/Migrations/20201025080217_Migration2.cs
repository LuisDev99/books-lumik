using Microsoft.EntityFrameworkCore.Migrations;

namespace books_lumik.Infrastructure.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechaPublicacion",
                table: "Libros",
                newName: "FechaPublicacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaPublicacion",
                table: "Libros",
                newName: "fechaPublicacion");
        }
    }
}
