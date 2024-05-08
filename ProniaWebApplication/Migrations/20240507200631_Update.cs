using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
