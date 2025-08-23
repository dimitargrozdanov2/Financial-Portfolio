using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Soft_Delete_Assets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Assets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Assets");
        }
    }
}
