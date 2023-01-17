using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postex.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changeaccounting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractInfoId",
                table: "cn_ContractAccountingTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractAccountingTemplates_ContractInfoId",
                table: "cn_ContractAccountingTemplates",
                column: "ContractInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_cn_ContractAccountingTemplates_cn_ContractsInfo_ContractInfoId",
                table: "cn_ContractAccountingTemplates",
                column: "ContractInfoId",
                principalTable: "cn_ContractsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cn_ContractAccountingTemplates_cn_ContractsInfo_ContractInfoId",
                table: "cn_ContractAccountingTemplates");

            migrationBuilder.DropIndex(
                name: "IX_cn_ContractAccountingTemplates_ContractInfoId",
                table: "cn_ContractAccountingTemplates");

            migrationBuilder.DropColumn(
                name: "ContractInfoId",
                table: "cn_ContractAccountingTemplates");
        }
    }
}
