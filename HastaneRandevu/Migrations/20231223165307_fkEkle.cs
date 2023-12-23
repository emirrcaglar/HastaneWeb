using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevu.Migrations
{
    /// <inheritdoc />
    public partial class fkEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bolumler",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "BolumId",
                table: "Doktorlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_BolumId",
                table: "Doktorlar",
                column: "BolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_Bolumler_BolumId",
                table: "Doktorlar",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_Bolumler_BolumId",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_BolumId",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "BolumId",
                table: "Doktorlar");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bolumler",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "bolumAdi",
                table: "Bolumler",
                newName: "ad");
        }
    }
}
