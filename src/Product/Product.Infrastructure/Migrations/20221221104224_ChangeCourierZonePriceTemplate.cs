using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Infrastructure.Migrations
{
    public partial class ChangeCourierZonePriceTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToCityId",
                table: "CourierZonePriceTemplates",
                newName: "ToCity");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "CourierZonePriceTemplates",
                newName: "FromCity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToCity",
                table: "CourierZonePriceTemplates",
                newName: "ToCityId");

            migrationBuilder.RenameColumn(
                name: "FromCity",
                table: "CourierZonePriceTemplates",
                newName: "ShopId");
        }
    }
}
