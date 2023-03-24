using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class ReferenceBuyerSellerToInscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "Seller",
                table: "Inscriptions");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Buyers_BuyerId",
                table: "Inscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Sellers_SellerId",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_BuyerId",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_SellerId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Inscriptions");

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
