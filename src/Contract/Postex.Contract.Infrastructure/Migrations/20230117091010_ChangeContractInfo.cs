using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postex.Contract.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeContractInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "cn_ContractsInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "cn_ContractsInfo",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "cn_ContractsInfo");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "cn_ContractsInfo");
        }
    }
}
