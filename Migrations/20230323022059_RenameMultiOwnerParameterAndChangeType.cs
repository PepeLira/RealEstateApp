using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameMultiOwnerParameterAndChangeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoyaltyPer",
                table: "MultiOwners",
                newName: "RoyaltyPercentage");

            migrationBuilder.AlterColumn<int>(
                name: "Commune",
                table: "MultiOwners",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoyaltyPercentage",
                table: "MultiOwners",
                newName: "RoyaltyPer");

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "MultiOwners",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
