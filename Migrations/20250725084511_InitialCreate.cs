using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KullaniciListe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciAdi = table.Column<string>(type: "TEXT", nullable: true),
                    KullaniciSoyadi = table.Column<string>(type: "TEXT", nullable: true),
                    KullaniciYas = table.Column<int>(type: "INTEGER", nullable: false),
                    KullaniciPozisyon = table.Column<string>(type: "TEXT", nullable: true),
                    KullaniciNumara = table.Column<int>(type: "INTEGER", nullable: false),
                    KullaniciMail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
