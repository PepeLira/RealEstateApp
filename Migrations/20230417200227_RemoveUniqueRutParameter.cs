using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueRutParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Buyers_Rut",
            table: "Buyers");

            migrationBuilder.DropIndex(
            name: "IX_Sellers_Rut",
            table: "Sellers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
            name: "IX_Buyers_Rut",
            table: "Buyers",
            column: "Rut",
            unique: true);

            migrationBuilder.CreateIndex(
            name: "IX_Sellers_Rut",
            table: "Sellers",
            column: "Rut",
            unique: true);
        }
    }
}
