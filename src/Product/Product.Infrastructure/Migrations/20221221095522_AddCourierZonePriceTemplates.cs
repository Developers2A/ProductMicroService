using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Infrastructure.Migrations
{
    public partial class AddCourierZonePriceTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourierZonePriceTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ToCityId = table.Column<int>(type: "int", nullable: false),
                    CourierServiceId = table.Column<int>(type: "int", nullable: false),
                    FromCourierZoneId = table.Column<int>(type: "int", nullable: false),
                    ToCourierZoneId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    SameState = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierZonePriceTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierZonePriceTemplates_CourierServices_CourierServiceId",
                        column: x => x.CourierServiceId,
                        principalTable: "CourierServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourierZonePriceTemplates_CourierServiceId",
                table: "CourierZonePriceTemplates",
                column: "CourierServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourierZonePriceTemplates");
        }
    }
}
