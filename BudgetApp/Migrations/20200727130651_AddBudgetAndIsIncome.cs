using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetApp.Migrations
{
    public partial class AddBudgetAndIsIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Budget_BudgetId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Budget_BudgetId1",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_BudgetId1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "BudgetId1",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "BudgetId",
                table: "Item",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "Item",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Budget_BudgetId",
                table: "Item",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Budget_BudgetId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "BudgetId",
                table: "Item",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BudgetId1",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_BudgetId1",
                table: "Item",
                column: "BudgetId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Budget_BudgetId",
                table: "Item",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Budget_BudgetId1",
                table: "Item",
                column: "BudgetId1",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
