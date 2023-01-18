using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Postex.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cn_ContractItemTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cn_ContractItemTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cn_ContractItemTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "cn_ContractItemTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
