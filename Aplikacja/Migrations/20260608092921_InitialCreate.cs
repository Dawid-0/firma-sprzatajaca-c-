using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplikacja.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    Adres = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    Wiek = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprzety",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Typ = table.Column<string>(type: "TEXT", nullable: false),
                    CzyDostepny = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzety", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uslugi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NazwaUslugi = table.Column<string>(type: "TEXT", nullable: false),
                    CenaPodstawowa = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uslugi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zlecenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataOd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KlientId = table.Column<int>(type: "INTEGER", nullable: false),
                    UslugaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PracownikId = table.Column<int>(type: "INTEGER", nullable: false),
                    SprzetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zlecenia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Klienci_KlientId",
                        column: x => x.KlientId,
                        principalTable: "Klienci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Pracownicy_PracownikId",
                        column: x => x.PracownikId,
                        principalTable: "Pracownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Sprzety_SprzetId",
                        column: x => x.SprzetId,
                        principalTable: "Sprzety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zlecenia_Uslugi_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Uslugi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_KlientId",
                table: "Zlecenia",
                column: "KlientId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_PracownikId",
                table: "Zlecenia",
                column: "PracownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_SprzetId",
                table: "Zlecenia",
                column: "SprzetId");

            migrationBuilder.CreateIndex(
                name: "IX_Zlecenia_UslugaId",
                table: "Zlecenia",
                column: "UslugaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zlecenia");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Sprzety");

            migrationBuilder.DropTable(
                name: "Uslugi");
        }
    }
}
