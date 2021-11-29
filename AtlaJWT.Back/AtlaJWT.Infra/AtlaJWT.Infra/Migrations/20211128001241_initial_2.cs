using Microsoft.EntityFrameworkCore.Migrations;

namespace AtlaJWT.Infra.Migrations
{
    public partial class initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUserInfo",
                table: "UserRegistered",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUserInfo",
                table: "UserRegistered");
        }
    }
}
