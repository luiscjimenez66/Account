using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.InfrastructureEF.Migrations
{
    public partial class Modified_Name_Transaction_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Balances_BalanceId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_BalanceId",
                table: "Transactions",
                newName: "IX_Transactions_BalanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Balances_BalanceId",
                table: "Transactions",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "BalanceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Balances_BalanceId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_BalanceId",
                table: "Transaction",
                newName: "IX_Transaction_BalanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Balances_BalanceId",
                table: "Transaction",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "BalanceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
