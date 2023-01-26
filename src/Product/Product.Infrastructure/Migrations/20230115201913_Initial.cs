using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoxPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_BoxPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourierLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_CourierLimits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostexCods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FromValue = table.Column<int>(type: "int", nullable: false),
                    ToValue = table.Column<int>(type: "int", nullable: false),
                    FixedValue = table.Column<int>(type: "int", nullable: false),
                    FixedPercent = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PostexCods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostexInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FromValue = table.Column<int>(type: "int", nullable: false),
                    ToValue = table.Column<int>(type: "int", nullable: false),
                    FixedValue = table.Column<int>(type: "int", nullable: false),
                    FixedPercent = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PostexInsurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceCode = table.Column<int>(type: "int", nullable: false),
                    PostUnitID = table.Column<int>(type: "int", nullable: false),
                    CityCode = table.Column<int>(type: "int", nullable: false),
                    PostnodeID = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    AdminAccepet = table.Column<bool>(type: "bit", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePlanID = table.Column<int>(type: "int", nullable: false),
                    CollectTypeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSiteURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountBranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountIban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerNationalID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerNationalIDSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerBirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerFatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerCertNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerCertSeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerCertSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPricePlanID = table.Column<int>(type: "int", nullable: false),
                    CompanyDiscountPercent = table.Column<int>(type: "int", nullable: false),
                    ShopDiscountPercent = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PostShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValueAddedPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValueAddedType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ValueAddedPrices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostageWeight = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_Weights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourierServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ForeignPost = table.Column<bool>(type: "bit", nullable: false),
                    DomesticPost = table.Column<bool>(type: "bit", nullable: false),
                    HasCollection = table.Column<bool>(type: "bit", nullable: false),
                    HasDistribution = table.Column<bool>(type: "bit", nullable: false),
                    BetweenCity = table.Column<bool>(type: "bit", nullable: false),
                    InnerCity = table.Column<bool>(type: "bit", nullable: false),
                    Parcel = table.Column<bool>(type: "bit", nullable: false),
                    Document = table.Column<bool>(type: "bit", nullable: false),
                    HasApi = table.Column<bool>(type: "bit", nullable: false),
                    CodPayment = table.Column<bool>(type: "bit", nullable: false),
                    NeedLatLon = table.Column<bool>(type: "bit", nullable: false),
                    Fragile = table.Column<bool>(type: "bit", nullable: false),
                    FreeShipping = table.Column<bool>(type: "bit", nullable: false),
                    PostPaid = table.Column<bool>(type: "bit", nullable: false),
                    Heavy = table.Column<bool>(type: "bit", nullable: false),
                    PriceHasDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    PriceHasTax = table.Column<bool>(type: "bit", nullable: false),
                    FixBasePrice = table.Column<long>(type: "bigint", nullable: false),
                    PostexPercent = table.Column<double>(type: "float", nullable: false),
                    PostexFixPrice = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CourierServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierServices_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityType = table.Column<int>(type: "int", nullable: false),
                    EntryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_CourierZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierZones_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierStatusMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_CourierStatusMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierStatusMappings_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierStatusMappings_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierCods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    FromValue = table.Column<int>(type: "int", nullable: false),
                    ToValue = table.Column<int>(type: "int", nullable: false),
                    FixedValue = table.Column<int>(type: "int", nullable: false),
                    FixedPercent = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CourierCods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierCods_CourierServices_CourierId",
                        column: x => x.CourierId,
                        principalTable: "CourierServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    FromValue = table.Column<int>(type: "int", nullable: false),
                    ToValue = table.Column<int>(type: "int", nullable: false),
                    FixedValue = table.Column<int>(type: "int", nullable: false),
                    FixedPercent = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CourierInsurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierInsurances_CourierServices_CourierId",
                        column: x => x.CourierId,
                        principalTable: "CourierServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierZonePriceTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromCity = table.Column<int>(type: "int", nullable: false),
                    ToCity = table.Column<int>(type: "int", nullable: false),
                    CourierServiceId = table.Column<int>(type: "int", nullable: false),
                    FromCourierZoneId = table.Column<int>(type: "int", nullable: false),
                    ToCourierZoneId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    SameState = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_CourierZonePriceTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierZonePriceTemplates_CourierServices_CourierServiceId",
                        column: x => x.CourierServiceId,
                        principalTable: "CourierServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourierZoneCollectionDistributionPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierZoneId = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_CourierZoneCollectionDistributionPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierZoneCollectionDistributionPrices_CourierZones_CourierZoneId",
                        column: x => x.CourierZoneId,
                        principalTable: "CourierZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierZonePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierServiceId = table.Column<int>(type: "int", nullable: false),
                    FromCourierZoneId = table.Column<int>(type: "int", nullable: false),
                    ToCourierZoneId = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    SameState = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_CourierZonePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierZonePrices_CourierServices_CourierServiceId",
                        column: x => x.CourierServiceId,
                        principalTable: "CourierServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierZonePrices_CourierZones_FromCourierZoneId",
                        column: x => x.FromCourierZoneId,
                        principalTable: "CourierZones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourierZonePrices_CourierZones_ToCourierZoneId",
                        column: x => x.ToCourierZoneId,
                        principalTable: "CourierZones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CityZipCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParcelCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_CityZipCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityZipCodes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierCityMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    MappedCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CourierServiceId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_CourierCityMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierCityMappings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierCityMappings_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierCityMappings_CourierServices_CourierServiceId",
                        column: x => x.CourierServiceId,
                        principalTable: "CourierServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourierLimitValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierId = table.Column<int>(type: "int", nullable: false),
                    CourierLimitId = table.Column<int>(type: "int", nullable: false),
                    LowerLimit = table.Column<float>(type: "real", nullable: false),
                    UpperLimit = table.Column<float>(type: "real", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    FromOrToType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CourierLimitValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierLimitValues_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourierLimitValues_CourierLimits_CourierLimitId",
                        column: x => x.CourierLimitId,
                        principalTable: "CourierLimits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierLimitValues_CourierServices_CourierId",
                        column: x => x.CourierId,
                        principalTable: "CourierServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierZoneCityMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourierZoneId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CourierZoneCityMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourierZoneCityMappings_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourierZoneCityMappings_CourierZones_CourierZoneId",
                        column: x => x.CourierZoneId,
                        principalTable: "CourierZones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CityZipCodes_CityId",
                table: "CityZipCodes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierCityMappings_CityId",
                table: "CourierCityMappings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierCityMappings_CourierId",
                table: "CourierCityMappings",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierCityMappings_CourierServiceId",
                table: "CourierCityMappings",
                column: "CourierServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierCods_CourierId",
                table: "CourierCods",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierInsurances_CourierId",
                table: "CourierInsurances",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierLimitValues_CityId",
                table: "CourierLimitValues",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierLimitValues_CourierId",
                table: "CourierLimitValues",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierLimitValues_CourierLimitId",
                table: "CourierLimitValues",
                column: "CourierLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierServices_CourierId",
                table: "CourierServices",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierStatusMappings_CourierId",
                table: "CourierStatusMappings",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierStatusMappings_StatusId",
                table: "CourierStatusMappings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZoneCityMappings_CityId",
                table: "CourierZoneCityMappings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZoneCityMappings_CourierZoneId",
                table: "CourierZoneCityMappings",
                column: "CourierZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZoneCollectionDistributionPrices_CourierZoneId",
                table: "CourierZoneCollectionDistributionPrices",
                column: "CourierZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZonePrices_CourierServiceId",
                table: "CourierZonePrices",
                column: "CourierServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZonePrices_FromCourierZoneId",
                table: "CourierZonePrices",
                column: "FromCourierZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZonePrices_ToCourierZoneId",
                table: "CourierZonePrices",
                column: "ToCourierZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZonePriceTemplates_CourierServiceId",
                table: "CourierZonePriceTemplates",
                column: "CourierServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierZones_CourierId",
                table: "CourierZones",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoxPrices");

            migrationBuilder.DropTable(
                name: "CityZipCodes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CourierCityMappings");

            migrationBuilder.DropTable(
                name: "CourierCods");

            migrationBuilder.DropTable(
                name: "CourierInsurances");

            migrationBuilder.DropTable(
                name: "CourierLimitValues");

            migrationBuilder.DropTable(
                name: "CourierStatusMappings");

            migrationBuilder.DropTable(
                name: "CourierZoneCityMappings");

            migrationBuilder.DropTable(
                name: "CourierZoneCollectionDistributionPrices");

            migrationBuilder.DropTable(
                name: "CourierZonePrices");

            migrationBuilder.DropTable(
                name: "CourierZonePriceTemplates");

            migrationBuilder.DropTable(
                name: "PostexCods");

            migrationBuilder.DropTable(
                name: "PostexInsurances");

            migrationBuilder.DropTable(
                name: "PostShops");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ValueAddedPrices");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "CourierLimits");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CourierZones");

            migrationBuilder.DropTable(
                name: "CourierServices");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Couriers");
        }
    }
}
