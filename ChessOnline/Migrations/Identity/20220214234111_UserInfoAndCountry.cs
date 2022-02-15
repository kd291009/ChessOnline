using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessOnline.Migrations.Identity
{
    public partial class UserInfoAndCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamesLost",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamesTied",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamesWon",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinPercentage",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GamesLost",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GamesTied",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GamesWon",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WinPercentage",
                table: "AspNetUsers");
        }
    }
}
