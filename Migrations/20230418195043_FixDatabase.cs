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
            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscriptions",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "Buyers",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "Sellers",
                table: "Inscriptions");

            migrationBuilder.RenameTable(
                name: "Inscriptions",
                newName: "Inscription");

            migrationBuilder.RenameColumn(
                name: "RoyaltyPer",
                table: "MultiOwners",
                newName: "RoyaltyPercentage");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Inscription",
                newName: "AttentionID");

            migrationBuilder.AlterColumn<int>(
                name: "FinalEffectiveYear",
                table: "MultiOwners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Block",
                table: "Inscription",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscription",
                table: "Inscription",
                column: "AttentionID");

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoyaltyPercentage = table.Column<int>(type: "int", nullable: false),
                    UnaccreditedRoyaltyPercentage = table.Column<bool>(type: "bit", nullable: false),
                    InscriptionAttentionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyers_Inscription_InscriptionAttentionID",
                        column: x => x.InscriptionAttentionID,
                        principalTable: "Inscription",
                        principalColumn: "AttentionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoyaltyPercentage = table.Column<int>(type: "int", nullable: false),
                    UnaccreditedRoyaltyPercentage = table.Column<bool>(type: "bit", nullable: false),
                    InscriptionAttentionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_Inscription_InscriptionAttentionID",
                        column: x => x.InscriptionAttentionID,
                        principalTable: "Inscription",
                        principalColumn: "AttentionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_InscriptionAttentionID",
                table: "Buyers",
                column: "InscriptionAttentionID");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_InscriptionAttentionID",
                table: "Sellers",
                column: "InscriptionAttentionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscription",
                table: "Inscription");

            migrationBuilder.RenameTable(
                name: "Inscription",
                newName: "Inscriptions");

            migrationBuilder.RenameColumn(
                name: "RoyaltyPercentage",
                table: "MultiOwners",
                newName: "RoyaltyPer");

            migrationBuilder.RenameColumn(
                name: "AttentionID",
                table: "Inscriptions",
                newName: "Id");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscriptions",
                table: "Inscriptions",
                column: "Id");
        }
    }
}
