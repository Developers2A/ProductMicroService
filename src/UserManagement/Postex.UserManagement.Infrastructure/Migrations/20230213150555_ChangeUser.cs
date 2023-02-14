using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postex.UserManagement.Infrastructure.Migrations
{
    public partial class ChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VerificationCodeType",
                table: "VerificationCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCodeType",
                table: "VerificationCodes");
        }
    }
}
