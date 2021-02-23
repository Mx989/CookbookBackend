using Microsoft.EntityFrameworkCore.Migrations;

namespace CookbookAPI.Migrations
{
    public partial class UpdateDb_AddUserJWTKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JWTKey",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JWTKey",
                table: "Users");
        }
    }
}
