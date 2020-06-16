using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.InfrastructureEF.Migrations
{
    public partial class Add_TransactionNro_TransactionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionNro",
                table: "Transactions",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionNro",
                table: "Transactions");
        }
    }
}
