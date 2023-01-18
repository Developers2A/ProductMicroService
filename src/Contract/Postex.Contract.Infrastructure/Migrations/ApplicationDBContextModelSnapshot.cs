﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Postex.Contract.Infrastructure.Data;

#nullable disable

namespace Postex.Contract.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Postex.Contract.Domain.BoxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("BoxType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            Height = 10.0,
                            IsRemoved = false,
                            Length = 15.0,
                            ModifiedBy = 0,
                            Name = "سایز 1",
                            Width = 10.0
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            Height = 10.0,
                            IsRemoved = false,
                            Length = 20.0,
                            ModifiedBy = 0,
                            Name = "سایز 2",
                            Width = 15.0
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            Height = 15.0,
                            IsRemoved = false,
                            Length = 20.0,
                            ModifiedBy = 0,
                            Name = "سایز 3",
                            Width = 20.0
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            Height = 20.0,
                            IsRemoved = false,
                            Length = 30.0,
                            ModifiedBy = 0,
                            Name = "سایز 4",
                            Width = 20.0
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            Height = 20.0,
                            IsRemoved = false,
                            Length = 35.0,
                            ModifiedBy = 0,
                            Name = "سایز 5",
                            Width = 25.0
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            Height = 20.0,
                            IsRemoved = false,
                            Length = 45.0,
                            ModifiedBy = 0,
                            Name = "سایز 6",
                            Width = 35.0
                        });
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractAccountingTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("ContractDetailId")
                        .HasColumnType("int");

                    b.Property<string>("ContractDetailType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("ContractInfoId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FixedValue")
                        .HasColumnType("int");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("PercentValue")
                        .HasColumnType("float");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ContractInfoId");

                    b.ToTable("cn_ContractAccountingTemplates", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractBoxPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoxTypeId")
                        .HasColumnType("int");

                    b.Property<double>("BuyPrice")
                        .HasColumnType("float");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ContractInfoId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BoxTypeId");

                    b.HasIndex("ContractInfoId");

                    b.HasIndex("CustomerId");

                    b.ToTable("cn_ContractBoxPrices", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractCod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractInfoId")
                        .HasColumnType("int");

                    b.Property<int>("CourierId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<double>("FixedPercent")
                        .HasColumnType("float");

                    b.Property<int>("FixedValue")
                        .HasColumnType("int");

                    b.Property<int>("FromValue")
                        .HasColumnType("int");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("ToValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractInfoId");

                    b.ToTable("cn_ContractCods", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractCollect_Distribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoxTypeId")
                        .HasColumnType("int");

                    b.Property<double>("BuyPrice")
                        .HasColumnType("float");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ContractInfoId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BoxTypeId");

                    b.HasIndex("ContractInfoId");

                    b.ToTable("cn_ContractCollect_Distributes", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractCourier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractInfoId")
                        .HasColumnType("int");

                    b.Property<int>("CourierId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("FixedDiscount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("PercentDiscount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ContractInfoId");

                    b.ToTable("cn_ContractCouriers", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ContractNo")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("cn_ContractsInfo", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractInsurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ContractInfoId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<double>("FixedPercent")
                        .HasColumnType("float");

                    b.Property<int>("FixedValue")
                        .HasColumnType("int");

                    b.Property<int>("FromValue")
                        .HasColumnType("int");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("ToValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractInfoId");

                    b.ToTable("cn_ContractInsurances", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BuyPrice")
                        .HasColumnType("float");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ContractInfoId")
                        .HasColumnType("int");

                    b.Property<int>("ContractItemTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CourierId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<double>("SalePrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ContractInfoId");

                    b.HasIndex("ContractItemTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("cn_ContractItems", (string)null);
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContractTypeCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ContractTypeName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("cn_ContractItemTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContractTypeCode = "01",
                            ContractTypeName = "پیام کوتاه",
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            IsRemoved = false,
                            ModifiedBy = 0
                        },
                        new
                        {
                            Id = 2,
                            ContractTypeCode = "02",
                            ContractTypeName = "چاپ فاکتور",
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            IsRemoved = false,
                            ModifiedBy = 0
                        },
                        new
                        {
                            Id = 3,
                            ContractTypeCode = "03",
                            ContractTypeName = "آواتار",
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            IsRemoved = false,
                            ModifiedBy = 0
                        },
                        new
                        {
                            Id = 4,
                            ContractTypeCode = "04",
                            ContractTypeName = "انبار",
                            CreatedBy = 0,
                            CreatedOn = new DateTime(2022, 12, 12, 12, 12, 0, 0, DateTimeKind.Unspecified),
                            IsRemoved = false,
                            ModifiedBy = 0
                        });
                });

            modelBuilder.Entity("Postex.Contract.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractAccountingTemplate", b =>
                {
                    b.HasOne("Postex.Contract.Domain.ContractInfo", "ContractInfo")
                        .WithMany()
                        .HasForeignKey("ContractInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContractInfo");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractBoxPrice", b =>
                {
                    b.HasOne("Postex.Contract.Domain.BoxType", "BoxType")
                        .WithMany()
                        .HasForeignKey("BoxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postex.Contract.Domain.ContractInfo", "ContractInfo")
                        .WithMany("ContractBoxPrices")
                        .HasForeignKey("ContractInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postex.Contract.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("BoxType");

                    b.Navigation("ContractInfo");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractCod", b =>
                {
                    b.HasOne("Postex.Contract.Domain.ContractInfo", "ContractInfo")
                        .WithMany("ContractCods")
                        .HasForeignKey("ContractInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContractInfo");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractCollect_Distribute", b =>
                {
                    b.HasOne("Postex.Contract.Domain.BoxType", "BoxType")
                        .WithMany()
                        .HasForeignKey("BoxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postex.Contract.Domain.ContractInfo", "ContractInfo")
                        .WithMany("ContractCollect_Distributes")
                        .HasForeignKey("ContractInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoxType");

                    b.Navigation("ContractInfo");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractCourier", b =>
                {
                    b.HasOne("Postex.Contract.Domain.ContractInfo", "ContractInfo")
                        .WithMany()
                        .HasForeignKey("ContractInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContractInfo");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractInfo", b =>
                {
                    b.HasOne("Postex.Contract.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractInsurance", b =>
                {
                    b.HasOne("Postex.Contract.Domain.ContractInfo", "ContractInfo")
                        .WithMany("ContractInsurances")
                        .HasForeignKey("ContractInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContractInfo");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractItem", b =>
                {
                    b.HasOne("Postex.Contract.Domain.ContractInfo", "ContractInfo")
                        .WithMany()
                        .HasForeignKey("ContractInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postex.Contract.Domain.ContractItemType", "ContractItemType")
                        .WithMany()
                        .HasForeignKey("ContractItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postex.Contract.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("ContractInfo");

                    b.Navigation("ContractItemType");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Postex.Contract.Domain.ContractInfo", b =>
                {
                    b.Navigation("ContractBoxPrices");

                    b.Navigation("ContractCods");

                    b.Navigation("ContractCollect_Distributes");

                    b.Navigation("ContractInsurances");
                });
#pragma warning restore 612, 618
        }
    }
}
