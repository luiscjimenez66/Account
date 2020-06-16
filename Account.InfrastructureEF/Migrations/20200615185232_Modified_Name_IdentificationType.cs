using Microsoft.EntityFrameworkCore.Migrations;

namespace Account.InfrastructureEF.Migrations
{
    public partial class Modified_Name_IdentificationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentificationType",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "IdentificationTypeId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_People_IdentificationTypeId",
                table: "People",
                column: "IdentificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_IdentificationTypes_IdentificationTypeId",
                table: "People",
                column: "IdentificationTypeId",
                principalTable: "IdentificationTypes",
                principalColumn: "IdentificationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_IdentificationTypes_IdentificationTypeId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_IdentificationTypeId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IdentificationTypeId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "IdentificationType",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
