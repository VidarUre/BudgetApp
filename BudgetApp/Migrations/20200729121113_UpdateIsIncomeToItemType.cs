using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetApp.Migrations
{
    public partial class UpdateIsIncomeToItemType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "Item",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Item");

            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
