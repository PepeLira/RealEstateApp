using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIscriptionIDName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerInscription_Inscription_InscriptionsId",
                table: "BuyerInscription");

            migrationBuilder.DropForeignKey(
                name: "FK_InscriptionSeller_Inscription_InscriptionsId",
                table: "InscriptionSeller");

            migrationBuilder.RenameColumn(
                name: "InscriptionsId",
                table: "InscriptionSeller",
                newName: "InscriptionsAttentionID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Inscription",
                newName: "AttentionID");

            migrationBuilder.RenameColumn(
                name: "InscriptionsId",
                table: "BuyerInscription",
                newName: "InscriptionsAttentionID");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerInscription_InscriptionsId",
                table: "BuyerInscription",
                newName: "IX_BuyerInscription_InscriptionsAttentionID");

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "MultiOwners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "Inscription",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerInscription_Inscription_InscriptionsAttentionID",
                table: "BuyerInscription",
                column: "InscriptionsAttentionID",
                principalTable: "Inscription",
                principalColumn: "AttentionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InscriptionSeller_Inscription_InscriptionsAttentionID",
                table: "InscriptionSeller",
                column: "InscriptionsAttentionID",
                principalTable: "Inscription",
                principalColumn: "AttentionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerInscription_Inscription_InscriptionsAttentionID",
                table: "BuyerInscription");

            migrationBuilder.DropForeignKey(
                name: "FK_InscriptionSeller_Inscription_InscriptionsAttentionID",
                table: "InscriptionSeller");

            migrationBuilder.RenameColumn(
                name: "InscriptionsAttentionID",
                table: "InscriptionSeller",
                newName: "InscriptionsId");

            migrationBuilder.RenameColumn(
                name: "AttentionID",
                table: "Inscription",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InscriptionsAttentionID",
                table: "BuyerInscription",
                newName: "InscriptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_BuyerInscription_InscriptionsAttentionID",
                table: "BuyerInscription",
                newName: "IX_BuyerInscription_InscriptionsId");

            migrationBuilder.AlterColumn<int>(
                name: "Commune",
                table: "MultiOwners",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Commune",
                table: "Inscription",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerInscription_Inscription_InscriptionsId",
                table: "BuyerInscription",
                column: "InscriptionsId",
                principalTable: "Inscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InscriptionSeller_Inscription_InscriptionsId",
                table: "InscriptionSeller",
                column: "InscriptionsId",
                principalTable: "Inscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
