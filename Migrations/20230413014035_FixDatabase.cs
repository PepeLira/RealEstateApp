using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class FixDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyers",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "Sellers",
                table: "Inscriptions");

            migrationBuilder.RenameColumn(
                name: "RoyaltyPer",
                table: "MultiOwners",
                newName: "RoyaltyPercentage");

            migrationBuilder.AlterColumn<int>(
                name: "FinalEffectiveYear",
                table: "MultiOwners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Block",
                table: "Inscriptions",
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

            migrationBuilder.AlterColumn<int>(
                name: "FinalEffectiveYear",
                table: "MultiOwners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Block",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Buyers",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sellers",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
