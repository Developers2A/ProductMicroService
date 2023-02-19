using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postex.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cn_ContractBoxPrices_Customer_CustomerId",
                table: "cn_ContractBoxPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_cn_ContractItems_Customer_CustomerId",
                table: "cn_ContractItems");

            migrationBuilder.DropForeignKey(
                name: "FK_cn_ContractsInfo_Customer_CustomerId",
                table: "cn_ContractsInfo");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_cn_ContractsInfo_CustomerId",
                table: "cn_ContractsInfo");

            migrationBuilder.DropIndex(
                name: "IX_cn_ContractItems_CustomerId",
                table: "cn_ContractItems");

            migrationBuilder.DropIndex(
                name: "IX_cn_ContractBoxPrices_CustomerId",
                table: "cn_ContractBoxPrices");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "cn_ContractItems");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "cn_ContractAccountingTemplates",
                newName: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "cn_ContractAccountingTemplates",
                newName: "AccountId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "cn_ContractItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractsInfo_CustomerId",
                table: "cn_ContractsInfo",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractItems_CustomerId",
                table: "cn_ContractItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractBoxPrices_CustomerId",
                table: "cn_ContractBoxPrices",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_cn_ContractBoxPrices_Customer_CustomerId",
                table: "cn_ContractBoxPrices",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cn_ContractItems_Customer_CustomerId",
                table: "cn_ContractItems",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cn_ContractsInfo_Customer_CustomerId",
                table: "cn_ContractsInfo",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
