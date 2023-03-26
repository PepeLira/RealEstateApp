using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class FixInscriptionSellerBuyerRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Buyers_BuyerId",
                table: "Inscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Sellers_SellerId",
                table: "Inscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscriptions",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_BuyerId",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_SellerId",
                table: "Inscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Inscriptions");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "Inscriptions",
                newName: "Inscription");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Buyer");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_Rut",
                table: "Seller",
                newName: "IX_Seller_Rut");

            migrationBuilder.RenameIndex(
                name: "IX_Buyers_Rut",
                table: "Buyer",
                newName: "IX_Buyer_Rut");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscription",
                table: "Inscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BuyerInscription",
                columns: table => new
                {
                    BuyersId = table.Column<int>(type: "int", nullable: false),
                    InscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerInscription", x => new { x.BuyersId, x.InscriptionsId });
                    table.ForeignKey(
                        name: "FK_BuyerInscription_Buyer_BuyersId",
                        column: x => x.BuyersId,
                        principalTable: "Buyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerInscription_Inscription_InscriptionsId",
                        column: x => x.InscriptionsId,
                        principalTable: "Inscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InscriptionSeller",
                columns: table => new
                {
                    InscriptionsId = table.Column<int>(type: "int", nullable: false),
                    SellersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscriptionSeller", x => new { x.InscriptionsId, x.SellersId });
                    table.ForeignKey(
                        name: "FK_InscriptionSeller_Inscription_InscriptionsId",
                        column: x => x.InscriptionsId,
                        principalTable: "Inscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscriptionSeller_Seller_SellersId",
                        column: x => x.SellersId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerInscription_InscriptionsId",
                table: "BuyerInscription",
                column: "InscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_InscriptionSeller_SellersId",
                table: "InscriptionSeller",
                column: "SellersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerInscription");

            migrationBuilder.DropTable(
                name: "InscriptionSeller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscription",
                table: "Inscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buyer");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Inscription",
                newName: "Inscriptions");

            migrationBuilder.RenameTable(
                name: "Buyer",
                newName: "Buyers");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_Rut",
                table: "Sellers",
                newName: "IX_Sellers_Rut");

            migrationBuilder.RenameIndex(
                name: "IX_Buyer_Rut",
                table: "Buyers",
                newName: "IX_Buyers_Rut");

            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Inscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Inscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscriptions",
                table: "Inscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_BuyerId",
                table: "Inscriptions",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_SellerId",
                table: "Inscriptions",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Buyers_BuyerId",
                table: "Inscriptions",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Sellers_SellerId",
                table: "Inscriptions",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
