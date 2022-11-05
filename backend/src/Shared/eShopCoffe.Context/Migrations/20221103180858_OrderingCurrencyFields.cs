using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopCoffe.Context.Migrations
{
    public partial class OrderingCurrencyFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyValue",
                table: "Order",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CurrencyValue",
                table: "Order");
        }
    }
}
