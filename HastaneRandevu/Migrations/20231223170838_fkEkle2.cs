using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevu.Migrations
{
    /// <inheritdoc />
    public partial class fkEkle2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DoktorId",
                table: "Bolumler",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bolumler_DoktorId",
                table: "Bolumler",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bolumler_Doktorlar_DoktorId",
                table: "Bolumler",
                column: "DoktorId",
                principalTable: "Doktorlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bolumler_Doktorlar_DoktorId",
                table: "Bolumler");

            migrationBuilder.DropIndex(
                name: "IX_Bolumler_DoktorId",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "DoktorId",
                table: "Bolumler");

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
    }
}
