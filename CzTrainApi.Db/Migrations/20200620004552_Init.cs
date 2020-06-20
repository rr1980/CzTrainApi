using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CzTrainApi.Db.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatalogObjekte",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Geloescht = table.Column<bool>(nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(nullable: false),
                    Aenderungsdatum = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Bezeichnung = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatalogObjekte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Geloescht = table.Column<bool>(nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(nullable: false),
                    Aenderungsdatum = table.Column<DateTime>(nullable: true),
                    Nachname = table.Column<string>(maxLength: 50, nullable: true),
                    Vorname = table.Column<string>(maxLength: 50, nullable: true),
                    Geburtstag = table.Column<DateTime>(nullable: false),
                    AnredeId = table.Column<long>(nullable: true),
                    TitelId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personen_KatalogObjekte_AnredeId",
                        column: x => x.AnredeId,
                        principalTable: "KatalogObjekte",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personen_KatalogObjekte_TitelId",
                        column: x => x.TitelId,
                        principalTable: "KatalogObjekte",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false),
                    Geloescht = table.Column<bool>(nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(nullable: false),
                    Aenderungsdatum = table.Column<DateTime>(nullable: true),
                    Strasse = table.Column<string>(maxLength: 100, nullable: true),
                    Plz = table.Column<string>(maxLength: 10, nullable: true),
                    Ort = table.Column<string>(maxLength: 50, nullable: true),
                    Hausnummer = table.Column<int>(nullable: false),
                    Hausnummerzusatz = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => new { x.Id, x.PersonId });
                    table.ForeignKey(
                        name: "FK_Adressen_Personen_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false),
                    Geloescht = table.Column<bool>(nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(nullable: false),
                    Aenderungsdatum = table.Column<DateTime>(nullable: true),
                    Benutzername = table.Column<string>(maxLength: 50, nullable: true),
                    Passwort = table.Column<string>(maxLength: 100, nullable: true),
                    BenutzerRolle = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => new { x.Id, x.PersonId });
                    table.ForeignKey(
                        name: "FK_Benutzer_Personen_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    PersonId = table.Column<long>(nullable: false),
                    Geloescht = table.Column<bool>(nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(nullable: false),
                    Aenderungsdatum = table.Column<DateTime>(nullable: true),
                    KundenNummer = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => new { x.Id, x.PersonId });
                    table.ForeignKey(
                        name: "FK_Kunden_Personen_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adressen_PersonId",
                table: "Adressen",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Benutzer_PersonId",
                table: "Benutzer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Kunden_PersonId",
                table: "Kunden",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Personen_AnredeId",
                table: "Personen",
                column: "AnredeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personen_TitelId",
                table: "Personen",
                column: "TitelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Benutzer");

            migrationBuilder.DropTable(
                name: "Kunden");

            migrationBuilder.DropTable(
                name: "Personen");

            migrationBuilder.DropTable(
                name: "KatalogObjekte");
        }
    }
}
