using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyConstarint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TypeValue_TypeId",
                table: "TypeValue",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeValue_Types_TypeId",
                table: "TypeValue",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeValue_Types_TypeId",
                table: "TypeValue");

            migrationBuilder.DropIndex(
                name: "IX_TypeValue_TypeId",
                table: "TypeValue");
        }
    }
}
