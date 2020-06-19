using Microsoft.EntityFrameworkCore.Migrations;

namespace CzTrainApi.Db.Migrations
{
    public partial class BenutzerRolle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BenutzerRolle",
                table: "Personen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenutzerRolle",
                table: "Kunden",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenutzerRolle",
                table: "Benutzer",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenutzerRolle",
                table: "Anreden",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenutzerRolle",
                table: "Adressen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BenutzerRolle",
                table: "Personen");

            migrationBuilder.DropColumn(
                name: "BenutzerRolle",
                table: "Kunden");

            migrationBuilder.DropColumn(
                name: "BenutzerRolle",
                table: "Benutzer");

            migrationBuilder.DropColumn(
                name: "BenutzerRolle",
                table: "Anreden");

            migrationBuilder.DropColumn(
                name: "BenutzerRolle",
                table: "Adressen");
        }
    }
}
