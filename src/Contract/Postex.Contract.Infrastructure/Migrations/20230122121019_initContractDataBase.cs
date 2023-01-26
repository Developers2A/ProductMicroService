using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Postex.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initContractDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoxType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_BoxType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractTypeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ContractTypeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractLeasings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ReturnRate = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithdrawRate = table.Column<double>(type: "float", nullable: false),
                    DailyDepositRateCeiling = table.Column<int>(type: "int", nullable: false),
                    DailyDepositeRate = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractLeasings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractLeasingWarranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractLeasingId = table.Column<int>(type: "int", nullable: false),
                    WarrantyNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyAmount = table.Column<int>(type: "int", nullable: false),
                    WarrantyReqistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarrantyEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractLeasingWarranties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractLeasingWarranties_cn_ContractLeasings_ContractLeasingId",
                        column: x => x.ContractLeasingId,
                        principalTable: "cn_ContractLeasings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNo = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractsInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractsInfo_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractAccountingTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    ContractDetailType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ContractDetailId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PercentValue = table.Column<double>(type: "float", nullable: false),
                    FixedValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractAccountingTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractAccountingTemplates_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "cn_ContractCods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    FromValue = table.Column<int>(type: "int", nullable: false),
                    ToValue = table.Column<int>(type: "int", nullable: false),
                    FixedPercent = table.Column<double>(type: "float", nullable: false),
                    FixedValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsActice = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractCods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractCods_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractCollect_Distributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    BoxTypeId = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsActice = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractCollect_Distributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractCollect_Distributes_BoxType_BoxTypeId",
                        column: x => x.BoxTypeId,
                        principalTable: "BoxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cn_ContractCollect_Distributes_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractCouriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    FixedDiscount = table.Column<int>(type: "int", nullable: false),
                    PercentDiscount = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractCouriers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractCouriers_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    FromValue = table.Column<int>(type: "int", nullable: false),
                    ToValue = table.Column<int>(type: "int", nullable: false),
                    FixedPercent = table.Column<double>(type: "float", nullable: false),
                    FixedValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsActice = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractInsurances_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cn_ContractItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractInfoId = table.Column<int>(type: "int", nullable: false),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    ContractItemTypeId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_cn_ContractItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cn_ContractItems_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cn_ContractItems_cn_ContractItemTypes_ContractItemTypeId",
                        column: x => x.ContractItemTypeId,
                        principalTable: "cn_ContractItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cn_ContractItems_cn_ContractsInfo_ContractInfoId",
                        column: x => x.ContractInfoId,
                        principalTable: "cn_ContractsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BoxType",
                columns: new[] { "Id", "CreatedOn", "Height", "IsRemoved", "Length", "ModifiedOn", "Name", "RemovedOn", "Width" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), 10.0, false, 15.0, null, "سایز 1", null, 10.0 },
                    { 2, new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), 10.0, false, 20.0, null, "سایز 2", null, 15.0 },
                    { 3, new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), 15.0, false, 20.0, null, "سایز 3", null, 20.0 },
                    { 4, new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), 20.0, false, 30.0, null, "سایز 4", null, 20.0 },
                    { 5, new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), 20.0, false, 35.0, null, "سایز 5", null, 25.0 },
                    { 6, new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), 20.0, false, 45.0, null, "سایز 6", null, 35.0 }
                });

            migrationBuilder.InsertData(
                table: "cn_ContractItemTypes",
                columns: new[] { "Id", "ContractTypeCode", "ContractTypeName", "CreatedOn", "IsRemoved", "ModifiedOn", "RemovedOn" },
                values: new object[,]
                {
                    { 1, "01", "پیام کوتاه", new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { 2, "02", "چاپ فاکتور", new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { 3, "03", "آواتار", new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { 4, "04", "انبار", new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified), false, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractAccountingTemplates_ContractInfoId",
                table: "cn_ContractAccountingTemplates",
                column: "ContractInfoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractCods_ContractInfoId",
                table: "cn_ContractCods",
                column: "ContractInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractCollect_Distributes_BoxTypeId",
                table: "cn_ContractCollect_Distributes",
                column: "BoxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractCollect_Distributes_ContractInfoId",
                table: "cn_ContractCollect_Distributes",
                column: "ContractInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractCouriers_ContractInfoId",
                table: "cn_ContractCouriers",
                column: "ContractInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractInsurances_ContractInfoId",
                table: "cn_ContractInsurances",
                column: "ContractInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractItems_ContractInfoId",
                table: "cn_ContractItems",
                column: "ContractInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractItems_ContractItemTypeId",
                table: "cn_ContractItems",
                column: "ContractItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractItems_CustomerId",
                table: "cn_ContractItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractLeasingWarranties_ContractLeasingId",
                table: "cn_ContractLeasingWarranties",
                column: "ContractLeasingId");

            migrationBuilder.CreateIndex(
                name: "IX_cn_ContractsInfo_CustomerId",
                table: "cn_ContractsInfo",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cn_ContractAccountingTemplates");

            migrationBuilder.DropTable(
                name: "cn_ContractBoxPrices");

            migrationBuilder.DropTable(
                name: "cn_ContractCods");

            migrationBuilder.DropTable(
                name: "cn_ContractCollect_Distributes");

            migrationBuilder.DropTable(
                name: "cn_ContractCouriers");

            migrationBuilder.DropTable(
                name: "cn_ContractInsurances");

            migrationBuilder.DropTable(
                name: "cn_ContractItems");

            migrationBuilder.DropTable(
                name: "cn_ContractLeasingWarranties");

            migrationBuilder.DropTable(
                name: "BoxType");

            migrationBuilder.DropTable(
                name: "cn_ContractItemTypes");

            migrationBuilder.DropTable(
                name: "cn_ContractsInfo");

            migrationBuilder.DropTable(
                name: "cn_ContractLeasings");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
