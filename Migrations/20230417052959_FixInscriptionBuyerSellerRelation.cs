using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class FixInscriptionBuyerSellerRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerInscription");

            migrationBuilder.DropTable(
                name: "InscriptionSeller");

            migrationBuilder.AddColumn<int>(
                name: "InscriptionAttentionID",
                table: "Seller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InscriptionAttentionID",
                table: "Buyer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_InscriptionAttentionID",
                table: "Seller",
                column: "InscriptionAttentionID");

            migrationBuilder.CreateIndex(
                name: "IX_Buyer_InscriptionAttentionID",
                table: "Buyer",
                column: "InscriptionAttentionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyer_Inscription_InscriptionAttentionID",
                table: "Buyer",
                column: "InscriptionAttentionID",
                principalTable: "Inscription",
                principalColumn: "AttentionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Inscription_InscriptionAttentionID",
                table: "Seller",
                column: "InscriptionAttentionID",
                principalTable: "Inscription",
                principalColumn: "AttentionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyer_Inscription_InscriptionAttentionID",
                table: "Buyer");

            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Inscription_InscriptionAttentionID",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_InscriptionAttentionID",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Buyer_InscriptionAttentionID",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "InscriptionAttentionID",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InscriptionAttentionID",
                table: "Buyer");

            migrationBuilder.CreateTable(
                name: "BuyerInscription",
                columns: table => new
                {
                    BuyersId = table.Column<int>(type: "int", nullable: false),
                    InscriptionsAttentionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerInscription", x => new { x.BuyersId, x.InscriptionsAttentionID });
                    table.ForeignKey(
                        name: "FK_BuyerInscription_Buyer_BuyersId",
                        column: x => x.BuyersId,
                        principalTable: "Buyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerInscription_Inscription_InscriptionsAttentionID",
                        column: x => x.InscriptionsAttentionID,
                        principalTable: "Inscription",
                        principalColumn: "AttentionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InscriptionSeller",
                columns: table => new
                {
                    InscriptionsAttentionID = table.Column<int>(type: "int", nullable: false),
                    SellersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscriptionSeller", x => new { x.InscriptionsAttentionID, x.SellersId });
                    table.ForeignKey(
                        name: "FK_InscriptionSeller_Inscription_InscriptionsAttentionID",
                        column: x => x.InscriptionsAttentionID,
                        principalTable: "Inscription",
                        principalColumn: "AttentionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscriptionSeller_Seller_SellersId",
                        column: x => x.SellersId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerInscription_InscriptionsAttentionID",
                table: "BuyerInscription",
                column: "InscriptionsAttentionID");

            migrationBuilder.CreateIndex(
                name: "IX_InscriptionSeller_SellersId",
                table: "InscriptionSeller",
                column: "SellersId");
        }
    }
}
