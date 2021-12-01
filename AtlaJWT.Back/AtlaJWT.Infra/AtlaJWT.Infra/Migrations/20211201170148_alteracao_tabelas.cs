using Microsoft.EntityFrameworkCore.Migrations;

namespace AtlaJWT.Infra.Migrations
{
    public partial class alteracao_tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserRegistered",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserRegistered",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserInfo",
                type: "TEXT",
                nullable: true);
        }
    }
}
