using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postex.Product.Infrastructure.Migrations
{
    public partial class AddValueAddedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ValueAddedPrices");

            migrationBuilder.RenameColumn(
                name: "ValueAddedType",
                table: "ValueAddedPrices",
                newName: "ValueAddedTypeId");

            migrationBuilder.RenameColumn(
                name: "ContractItemType",
                table: "ContractItems",
                newName: "ContractItemTypeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ValueAddedPrices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ContractItems",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.CreateTable(
                name: "ValueAddedTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueAddedTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValueAddedPrices_ValueAddedTypeId",
                table: "ValueAddedPrices",
                column: "ValueAddedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_ContractItemTypeId",
                table: "ContractItems",
                column: "ContractItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractItems_ValueAddedTypes_ContractItemTypeId",
                table: "ContractItems",
                column: "ContractItemTypeId",
                principalTable: "ValueAddedTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ValueAddedPrices_ValueAddedTypes_ValueAddedTypeId",
                table: "ValueAddedPrices",
                column: "ValueAddedTypeId",
                principalTable: "ValueAddedTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractItems_ValueAddedTypes_ContractItemTypeId",
                table: "ContractItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ValueAddedPrices_ValueAddedTypes_ValueAddedTypeId",
                table: "ValueAddedPrices");

            migrationBuilder.DropTable(
                name: "ValueAddedTypes");

            migrationBuilder.DropIndex(
                name: "IX_ValueAddedPrices_ValueAddedTypeId",
                table: "ValueAddedPrices");

            migrationBuilder.DropIndex(
                name: "IX_ContractItems_ContractItemTypeId",
                table: "ContractItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ValueAddedPrices");

            migrationBuilder.RenameColumn(
                name: "ValueAddedTypeId",
                table: "ValueAddedPrices",
                newName: "ValueAddedType");

            migrationBuilder.RenameColumn(
                name: "ContractItemTypeId",
                table: "ContractItems",
                newName: "ContractItemType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ValueAddedPrices",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ContractItems",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);
        }
    }
}
