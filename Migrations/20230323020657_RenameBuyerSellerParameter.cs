using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameBuyerSellerParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnaccreditedRoyaltyPer",
                table: "Sellers",
                newName: "UnaccreditedRoyaltyPercentage");

            migrationBuilder.RenameColumn(
                name: "RoyaltyPer",
                table: "Sellers",
                newName: "RoyaltyPercentage");

            migrationBuilder.RenameColumn(
                name: "UnaccreditedRoyaltyPer",
                table: "Buyers",
                newName: "UnaccreditedRoyaltyPercentage");

            migrationBuilder.RenameColumn(
                name: "RoyaltyPer",
                table: "Buyers",
                newName: "RoyaltyPercentage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnaccreditedRoyaltyPercentage",
                table: "Sellers",
                newName: "UnaccreditedRoyaltyPer");

            migrationBuilder.RenameColumn(
                name: "RoyaltyPercentage",
                table: "Sellers",
                newName: "RoyaltyPer");

            migrationBuilder.RenameColumn(
                name: "UnaccreditedRoyaltyPercentage",
                table: "Buyers",
                newName: "UnaccreditedRoyaltyPer");

            migrationBuilder.RenameColumn(
                name: "RoyaltyPercentage",
                table: "Buyers",
                newName: "RoyaltyPer");
        }
    }
}
