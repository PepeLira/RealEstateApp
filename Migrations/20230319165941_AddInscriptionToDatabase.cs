using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateApp.Migrations
{
    /// <inheritdoc />
    public partial class AddInscriptionToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sellers = table.Column<int>(type: "int", nullable: false),
                    Buyers = table.Column<int>(type: "int", nullable: false),
                    Fojas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InscriptionNumber = table.Column<int>(type: "int", nullable: false),
                    InscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");
        }
    }
}
