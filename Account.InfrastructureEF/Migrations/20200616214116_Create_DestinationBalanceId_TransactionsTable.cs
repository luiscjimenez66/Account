using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.InfrastructureEF.Migrations
{
    public partial class Create_DestinationBalanceId_TransactionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Balances_BalanceId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(22, 4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "DestinationBalanceId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransactionsTypes",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsTypes", x => x.TransactionTypeId);
                });

            migrationBuilder.InsertData(
                table: "TransactionsTypes",
                columns: new[] { "TransactionTypeId", "TransactionTypeName" },
                values: new object[] { 1, "Deposit" });

            migrationBuilder.InsertData(
                table: "TransactionsTypes",
                columns: new[] { "TransactionTypeId", "TransactionTypeName" },
                values: new object[] { 2, "Withdraw" });

            migrationBuilder.InsertData(
                table: "TransactionsTypes",
                columns: new[] { "TransactionTypeId", "TransactionTypeName" },
                values: new object[] { 3, "Transfer Money" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationBalanceId",
                table: "Transactions",
                column: "DestinationBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Balances_BalanceId",
                table: "Transactions",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "BalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Balances_DestinationBalanceId",
                table: "Transactions",
                column: "DestinationBalanceId",
                principalTable: "Balances",
                principalColumn: "BalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Balances_BalanceId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Balances_DestinationBalanceId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionsTypes");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DestinationBalanceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DestinationBalanceId",
                table: "Transactions");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(22, 4)");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Balances_BalanceId",
                table: "Transactions",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "BalanceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
