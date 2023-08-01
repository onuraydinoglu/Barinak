using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barinak.Migrations
{
    /// <inheritdoc />
    public partial class iki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turler_Kategoriler_KategoriID",
                table: "Turler");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Turler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Turler_Kategoriler_KategoriID",
                table: "Turler",
                column: "KategoriID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turler_Kategoriler_KategoriID",
                table: "Turler");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Turler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turler_Kategoriler_KategoriID",
                table: "Turler",
                column: "KategoriID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
