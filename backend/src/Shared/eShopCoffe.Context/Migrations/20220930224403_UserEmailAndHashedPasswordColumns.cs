using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopCoffe.Context.Migrations
{
    public partial class UserEmailAndHashedPasswordColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "User",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "Login");
        }
    }
}
