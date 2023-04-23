using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServisProduct.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdType",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdType",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
