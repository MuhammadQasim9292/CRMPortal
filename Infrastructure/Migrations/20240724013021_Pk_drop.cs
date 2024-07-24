using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pk_drop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TypeValue",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Types",
                newName: "ID");

            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "TypeValue",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "TypeValue");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TypeValue",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Types",
                newName: "Id");
        }
    }
}
