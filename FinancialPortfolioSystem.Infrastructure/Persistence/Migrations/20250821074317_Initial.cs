using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetType = table.Column<int>(type: "int", nullable: false),
                    TickerSymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MarketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.CheckConstraint("CK_Asset_Description", "LEN([Description]) >= 10");
                    table.CheckConstraint("CK_Asset_MarketPrice", "[MarketPrice] > 0");
                    table.CheckConstraint("CK_Asset_Name", "LEN([Name]) >= 2");
                    table.CheckConstraint("CK_Asset_TickerSymbol", "LEN([TickerSymbol]) >= 1");
                });

            migrationBuilder.CreateTable(
                name: "ClientPortfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPortfolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AverageCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientPortfolioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAssets", x => x.Id);
                    table.CheckConstraint("CK_ClientAsset_AverageCost", "[AverageCost] >= 0");
                    table.CheckConstraint("CK_ClientAsset_Quantity", "[Quantity] >= 0");
                    table.ForeignKey(
                        name: "FK_ClientAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAssets_ClientPortfolios_ClientPortfolioId",
                        column: x => x.ClientPortfolioId,
                        principalTable: "ClientPortfolios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientPortfolioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTransactions", x => x.Id);
                    table.CheckConstraint("CK_ClientTransaction_PricePerUnit", "[PricePerUnit] > 0");
                    table.CheckConstraint("CK_ClientTransaction_Quantity", "[Quantity] >= 1");
                    table.ForeignKey(
                        name: "FK_ClientTransactions_ClientPortfolios_ClientPortfolioId",
                        column: x => x.ClientPortfolioId,
                        principalTable: "ClientPortfolios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientAssets_AssetId",
                table: "ClientAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAssets_ClientPortfolioId",
                table: "ClientAssets",
                column: "ClientPortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTransactions_ClientPortfolioId",
                table: "ClientTransactions",
                column: "ClientPortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAssets");

            migrationBuilder.DropTable(
                name: "ClientTransactions");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "ClientPortfolios");
        }
    }
}
