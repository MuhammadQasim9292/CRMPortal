using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColoumnNamesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TypeValue",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Types",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypeValue",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Types",
                newName: "ID");
        }
    }
}
