using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barinak.Migrations
{
    /// <inheritdoc />
    public partial class ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    TurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurCins = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurYas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.TurID);
                    table.ForeignKey(
                        name: "FK_Turler_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turler_KategoriID",
                table: "Turler",
                column: "KategoriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
