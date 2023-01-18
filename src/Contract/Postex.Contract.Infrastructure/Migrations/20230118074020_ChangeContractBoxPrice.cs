using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postex.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeContractBoxPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cn_ContractBoxTypes");

            migrationBuilder.CreateTable(
                name: "cn_ContractBoxPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxTypeId = table.Column<int>(type: "int", nullable: false),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cn_ContractBoxPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractBoxPrices_BoxType_BoxTypeId",
                        column: x => x.BoxTypeId,
                        principalTable: "BoxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cn_ContractBoxPrices_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cn_ContractBoxPrices_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractBoxPrices_BoxTypeId",
                table: "cn_ContractBoxPrices",
                column: "BoxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractBoxPrices_ContractInfoId",
                table: "cn_ContractBoxPrices",
                column: "ContractInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractBoxPrices_CustomerId",
                table: "cn_ContractBoxPrices",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cn_ContractBoxPrices");

            migrationBuilder.CreateTable(
                name: "cn_ContractBoxTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxTypeId = table.Column<int>(type: "int", nullable: false),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cn_ContractBoxTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractBoxTypes_BoxType_BoxTypeId",
                        column: x => x.BoxTypeId,
                        principalTable: "BoxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cn_ContractBoxTypes_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cn_ContractBoxTypes_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractBoxTypes_BoxTypeId",
                table: "cn_ContractBoxTypes",
                column: "BoxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractBoxTypes_ContractInfoId",
                table: "cn_ContractBoxTypes",
                column: "ContractInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractBoxTypes_CustomerId",
                table: "cn_ContractBoxTypes",
                column: "CustomerId");
        }
    }
}
