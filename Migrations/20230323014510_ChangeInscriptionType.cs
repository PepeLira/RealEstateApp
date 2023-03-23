using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInscriptionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sellers",
                table: "Inscriptions",
                newName: "Seller");

            migrationBuilder.RenameColumn(
                name: "Buyers",
                table: "Inscriptions",
                newName: "Buyer");

            migrationBuilder.AlterColumn<int>(
                name: "Commune",
                table: "Inscriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "Seller",
                table: "Inscriptions",
                newName: "Sellers");

            migrationBuilder.RenameColumn(
                name: "Buyer",
                table: "Inscriptions",
                newName: "Buyers");

            migrationBuilder.AlterColumn<string>(
                name: "Commune",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Block",
                table: "Inscriptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
