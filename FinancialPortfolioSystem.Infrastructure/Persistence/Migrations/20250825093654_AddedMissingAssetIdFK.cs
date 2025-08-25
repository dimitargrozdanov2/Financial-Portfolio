using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Migrations;

/// <inheritdoc />
public partial class AddedMissingAssetIdFK : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_ClientTransactions_AssetId",
            table: "ClientTransactions",
            column: "AssetId");

        migrationBuilder.AddForeignKey(
            name: "FK_ClientTransactions_Assets_AssetId",
            table: "ClientTransactions",
            column: "AssetId",
            principalTable: "Assets",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_ClientTransactions_Assets_AssetId",
            table: "ClientTransactions");

        migrationBuilder.DropIndex(
            name: "IX_ClientTransactions_AssetId",
            table: "ClientTransactions");
    }
}
