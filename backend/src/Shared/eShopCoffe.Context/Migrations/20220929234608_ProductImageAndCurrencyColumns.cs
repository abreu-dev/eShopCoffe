using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopCoffe.Context.Migrations
{
    public partial class ProductImageAndCurrencyColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyValue",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CurrencyValue",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Product");
        }
    }
}
