using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopCoffe.Context.Migrations
{
    public partial class UserPasswordResetCodeAndDateColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireTemporaryPasswordResetCode",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HashedTemporaryPasswordResetCode",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireTemporaryPasswordResetCode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HashedTemporaryPasswordResetCode",
                table: "User");
        }
    }
}
