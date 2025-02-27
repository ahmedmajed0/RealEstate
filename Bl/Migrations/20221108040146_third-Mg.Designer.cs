﻿// <auto-generated />
using System;
using Bl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bl.Migrations
{
    [DbContext(typeof(RealestateContext))]
    [Migration("20221108040146_third-Mg")]
    partial class thirdMg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domains.TbAgricultural", b =>
                {
                    b.Property<int>("AgrculturalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Agrcultural_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgrculturalId"), 1L, 1);

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatePhone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PurposeId")
                        .HasColumnType("int")
                        .HasColumnName("Purpose_Id");

                    b.Property<int?>("SubClaId")
                        .HasColumnType("int")
                        .HasColumnName("SubCla_Id");

                    b.Property<int>("TowersNo")
                        .HasColumnType("int");

                    b.Property<string>("Types")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("AgrculturalId")
                        .HasName("PK_TbAgrcultural");

                    b.HasIndex("PurposeId");

                    b.HasIndex("SubClaId");

                    b.ToTable("TbAgricultural", (string)null);
                });

            modelBuilder.Entity("Domains.TbCommercial", b =>
                {
                    b.Property<int>("CommercialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Commercial_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommercialId"), 1L, 1);

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<byte>("Baths")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatePhone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PurposeId")
                        .HasColumnType("int")
                        .HasColumnName("Purpose_Id");

                    b.Property<int?>("SubClaId")
                        .HasColumnType("int")
                        .HasColumnName("SubCla_Id");

                    b.HasKey("CommercialId");

                    b.HasIndex("PurposeId");

                    b.HasIndex("SubClaId");

                    b.ToTable("TbCommercial", (string)null);
                });

            modelBuilder.Entity("Domains.TbEstateClassification", b =>
                {
                    b.Property<int>("ClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Classification_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassificationId"), 1L, 1);

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ClassificationId");

                    b.ToTable("TbEstateClassification", (string)null);
                });

            modelBuilder.Entity("Domains.TbImage", b =>
                {
                    b.Property<int>("ImgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("img_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImgId"), 1L, 1);

                    b.Property<int?>("AgrculturalId")
                        .HasColumnType("int")
                        .HasColumnName("Agrcultural_Id");

                    b.Property<int?>("CommercialId")
                        .HasColumnType("int")
                        .HasColumnName("Commercial_Id");

                    b.Property<string>("ImageName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("IndustrialId")
                        .HasColumnType("int")
                        .HasColumnName("Industrial_Id");

                    b.Property<int?>("ResidentialId")
                        .HasColumnType("int")
                        .HasColumnName("Residential_Id");

                    b.HasKey("ImgId");

                    b.ToTable("TbImages");
                });

            modelBuilder.Entity("Domains.TbIndustrial", b =>
                {
                    b.Property<int>("IndustrialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Industrial_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndustrialId"), 1L, 1);

                    b.Property<bool>("Aluminum")
                        .HasColumnType("bit");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<bool>("CarWorkshop")
                        .HasColumnType("bit");

                    b.Property<bool>("Carpentry")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatePhone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("HeavyEquipment")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Metalworks")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PurposeId")
                        .HasColumnType("int")
                        .HasColumnName("Purpose_Id");

                    b.Property<int?>("SubClaId")
                        .HasColumnType("int")
                        .HasColumnName("SubCla_Id");

                    b.HasKey("IndustrialId");

                    b.HasIndex("PurposeId");

                    b.HasIndex("SubClaId");

                    b.ToTable("TbIndustrial", (string)null);
                });

            modelBuilder.Entity("Domains.TbPurpose", b =>
                {
                    b.Property<int>("PurposeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Purpose_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurposeId"), 1L, 1);

                    b.Property<string>("PurposeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PurposeId");

                    b.ToTable("TbPurpose", (string)null);
                });

            modelBuilder.Entity("Domains.TbResidential", b =>
                {
                    b.Property<int>("ResidentialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Residential_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResidentialId"), 1L, 1);

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<byte>("Baths")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstateTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("FinKitchen")
                        .HasColumnType("bit")
                        .HasColumnName("Fin_Kitchen");

                    b.Property<byte>("HallsNo")
                        .HasColumnType("tinyint");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PurposeId")
                        .HasColumnType("int")
                        .HasColumnName("Purpose_Id");

                    b.Property<bool>("Roof")
                        .HasColumnType("bit");

                    b.Property<byte>("RoomsNo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("StoreHouse")
                        .HasColumnType("bit");

                    b.Property<int?>("SubClaId")
                        .HasColumnType("int")
                        .HasColumnName("SubCla_Id");

                    b.Property<bool>("Yard")
                        .HasColumnType("bit");

                    b.HasKey("ResidentialId");

                    b.HasIndex("PurposeId");

                    b.HasIndex("SubClaId");

                    b.ToTable("TbResidential", (string)null);
                });

            modelBuilder.Entity("Domains.TbSubClassification", b =>
                {
                    b.Property<int>("SubClaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SubCla_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubClaId"), 1L, 1);

                    b.Property<int?>("ClassificationId")
                        .HasColumnType("int")
                        .HasColumnName("Classification_Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SubClaId");

                    b.HasIndex("ClassificationId");

                    b.ToTable("TbSubClassification", (string)null);
                });

            modelBuilder.Entity("Domains.TbTeam", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Member_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("char(12)")
                        .IsFixedLength();

                    b.HasKey("MemberId");

                    b.ToTable("TbTeam", (string)null);
                });

            modelBuilder.Entity("Domains.VwAgricultural", b =>
                {
                    b.Property<int>("AgrculturalId")
                        .HasColumnType("int")
                        .HasColumnName("Agrcultural_Id");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatePhone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurposeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TowersNo")
                        .HasColumnType("int");

                    b.Property<string>("Types")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.ToView("VwAgricultural");
                });

            modelBuilder.Entity("Domains.VwCommercial", b =>
                {
                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<byte>("Baths")
                        .HasColumnType("tinyint");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CommercialId")
                        .HasColumnType("int")
                        .HasColumnName("Commercial_Id");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatePhone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurposeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.ToView("VwCommercial");
                });

            modelBuilder.Entity("Domains.VwIndustrial", b =>
                {
                    b.Property<bool>("Aluminum")
                        .HasColumnType("bit");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<bool>("CarWorkshop")
                        .HasColumnType("bit");

                    b.Property<bool>("Carpentry")
                        .HasColumnType("bit");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatePhone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("HeavyEquipment")
                        .HasColumnType("bit");

                    b.Property<int>("IndustrialId")
                        .HasColumnType("int")
                        .HasColumnName("Industrial_Id");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("Metalworks")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurposeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.ToView("VwIndustrial");
                });

            modelBuilder.Entity("Domains.VwResidential", b =>
                {
                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<byte>("Baths")
                        .HasColumnType("tinyint");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("DateOfPuplish")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatePhone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("FinKitchen")
                        .HasColumnType("bit")
                        .HasColumnName("Fin_Kitchen");

                    b.Property<byte>("HallsNo")
                        .HasColumnType("tinyint");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurposeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ResidentialId")
                        .HasColumnType("int")
                        .HasColumnName("Residential_Id");

                    b.Property<bool>("Roof")
                        .HasColumnType("bit");

                    b.Property<byte>("RoomsNo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("StoreHouse")
                        .HasColumnType("bit");

                    b.Property<bool>("Yard")
                        .HasColumnType("bit");

                    b.ToView("VwResidential");
                });

            modelBuilder.Entity("Domains.TbAgricultural", b =>
                {
                    b.HasOne("Domains.TbPurpose", "Purpose")
                        .WithMany("TbAgriculturals")
                        .HasForeignKey("PurposeId")
                        .HasConstraintName("FK_TbAgricultural_TbPurpose");

                    b.HasOne("Domains.TbSubClassification", "SubCla")
                        .WithMany("TbAgriculturals")
                        .HasForeignKey("SubClaId")
                        .HasConstraintName("FK_TbAgricultural_TbSubClassification");

                    b.Navigation("Purpose");

                    b.Navigation("SubCla");
                });

            modelBuilder.Entity("Domains.TbCommercial", b =>
                {
                    b.HasOne("Domains.TbPurpose", "Purpose")
                        .WithMany("TbCommercials")
                        .HasForeignKey("PurposeId")
                        .HasConstraintName("FK_TbCommercial_TbPurpose");

                    b.HasOne("Domains.TbSubClassification", "SubCla")
                        .WithMany("TbCommercials")
                        .HasForeignKey("SubClaId")
                        .HasConstraintName("FK_TbCommercial_TbSubClassification");

                    b.Navigation("Purpose");

                    b.Navigation("SubCla");
                });

            modelBuilder.Entity("Domains.TbIndustrial", b =>
                {
                    b.HasOne("Domains.TbPurpose", "Purpose")
                        .WithMany("TbIndustrials")
                        .HasForeignKey("PurposeId")
                        .HasConstraintName("FK_TbIndustrial_TbPurpose");

                    b.HasOne("Domains.TbSubClassification", "SubCla")
                        .WithMany("TbIndustrials")
                        .HasForeignKey("SubClaId")
                        .HasConstraintName("FK_TbIndustrial_TbSubClassification");

                    b.Navigation("Purpose");

                    b.Navigation("SubCla");
                });

            modelBuilder.Entity("Domains.TbResidential", b =>
                {
                    b.HasOne("Domains.TbPurpose", "Purpose")
                        .WithMany("TbResidentials")
                        .HasForeignKey("PurposeId")
                        .HasConstraintName("FK_TbResidential_TbPurpose");

                    b.HasOne("Domains.TbSubClassification", "SubCla")
                        .WithMany("TbResidentials")
                        .HasForeignKey("SubClaId")
                        .HasConstraintName("FK_TbResidential_TbSubClassification");

                    b.Navigation("Purpose");

                    b.Navigation("SubCla");
                });

            modelBuilder.Entity("Domains.TbSubClassification", b =>
                {
                    b.HasOne("Domains.TbEstateClassification", "Classification")
                        .WithMany("TbSubClassifications")
                        .HasForeignKey("ClassificationId")
                        .HasConstraintName("FK_TbSubClassification_TbEstateClassification");

                    b.Navigation("Classification");
                });

            modelBuilder.Entity("Domains.TbEstateClassification", b =>
                {
                    b.Navigation("TbSubClassifications");
                });

            modelBuilder.Entity("Domains.TbPurpose", b =>
                {
                    b.Navigation("TbAgriculturals");

                    b.Navigation("TbCommercials");

                    b.Navigation("TbIndustrials");

                    b.Navigation("TbResidentials");
                });

            modelBuilder.Entity("Domains.TbSubClassification", b =>
                {
                    b.Navigation("TbAgriculturals");

                    b.Navigation("TbCommercials");

                    b.Navigation("TbIndustrials");

                    b.Navigation("TbResidentials");
                });
#pragma warning restore 612, 618
        }
    }
}
