using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Bl
{
    public partial class RealestateContext : IdentityDbContext<ApplicationUser>
    {
        public RealestateContext()
        {
        }

        public RealestateContext(DbContextOptions<RealestateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAgricultural> TbAgricultural { get; set; } = null!;
        public virtual DbSet<TbCommercial> TbCommercial { get; set; } = null!;
        public virtual DbSet<TbEstateClassification> TbEstateClassification { get; set; } = null!;
        public virtual DbSet<TbImage> TbImages { get; set; } = null!;
        public virtual DbSet<TbIndustrial> TbIndustrial { get; set; } = null!;
        public virtual DbSet<TbPurpose> TbPurpose { get; set; } = null!;
        public virtual DbSet<TbResidential> TbResidential { get; set; } = null!;
        public virtual DbSet<TbSubClassification> TbSubClassification { get; set; } = null!;
        public virtual DbSet<TbTeam> TbTeams { get; set; } = null!;
        public virtual DbSet<TbAds> TbAds { get; set; } = null!;
        
        public virtual DbSet<VwAgricultural> VwAgricultural { get; set; } = null!;
        public virtual DbSet<VwCommercial> VwCommercial { get; set; } = null!;
        public virtual DbSet<VwIndustrial> VwIndustrial { get; set; } = null!;
        public virtual DbSet<VwResidential> VwResidential { get; set; } = null!;
        public virtual DbSet<VwResidentialHome> VwResidentialHome { get; set; } = null!;
        public virtual DbSet<VwIndustrialHome> VwIndustrialHome { get; set; } = null!;
        public virtual DbSet<VwCommercialHome> VwCommercialHome { get; set; } = null!;
        public virtual DbSet<VwAgriculturalHome> VwAgriculturalHome { get; set; } = null!;
        





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "Security");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security");

            modelBuilder.Entity<TbAgricultural>(entity =>
            {
                entity.HasKey(e => e.AgrculturalId)
                    .HasName("PK_TbAgrcultural");

                entity.ToTable("TbAgricultural");

                entity.Property(e => e.AgrculturalId).HasColumnName("Agrcultural_Id");

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_Id");

                entity.Property(e => e.SubClaId).HasColumnName("SubCla_Id");

                entity.Property(e => e.Types).HasMaxLength(300);

                entity.HasOne(d => d.Purpose)
                    .WithMany(p => p.TbAgriculturals)
                    .HasForeignKey(d => d.PurposeId)
                    .HasConstraintName("FK_TbAgricultural_TbPurpose");

                entity.HasOne(d => d.SubCla)
                    .WithMany(p => p.TbAgriculturals)
                    .HasForeignKey(d => d.SubClaId)
                    .HasConstraintName("FK_TbAgricultural_TbSubClassification");
            });

            modelBuilder.Entity<TbCommercial>(entity =>
            {
                entity.HasKey(e => e.CommercialId);

                entity.ToTable("TbCommercial");

                entity.Property(e => e.CommercialId).HasColumnName("Commercial_Id");

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_Id");

                entity.Property(e => e.SubClaId).HasColumnName("SubCla_Id");

                entity.HasOne(d => d.Purpose)
                    .WithMany(p => p.TbCommercials)
                    .HasForeignKey(d => d.PurposeId)
                    .HasConstraintName("FK_TbCommercial_TbPurpose");

                entity.HasOne(d => d.SubCla)
                    .WithMany(p => p.TbCommercials)
                    .HasForeignKey(d => d.SubClaId)
                    .HasConstraintName("FK_TbCommercial_TbSubClassification");
            });

            modelBuilder.Entity<TbEstateClassification>(entity =>
            {
                entity.HasKey(e => e.ClassificationId);

                entity.ToTable("TbEstateClassification");

                entity.Property(e => e.ClassificationId).HasColumnName("Classification_Id");

                entity.Property(e => e.Classification).HasMaxLength(30);
            });

            modelBuilder.Entity<TbImage>(entity =>
            {
                entity.HasKey(e => e.ImgId);

                entity.Property(e => e.ImgId).HasColumnName("img_Id");

                entity.Property(e => e.AgrculturalId).HasColumnName("Agrcultural_Id");

                entity.Property(e => e.CommercialId).HasColumnName("Commercial_Id");

                entity.Property(e => e.ImageName).HasMaxLength(100);

                entity.Property(e => e.IndustrialId).HasColumnName("Industrial_Id");

                entity.Property(e => e.ResidentialId).HasColumnName("Residential_Id");
            });

            modelBuilder.Entity<TbAds>(entity =>
            {
                entity.HasKey(e => e.AdId);
                entity.Property(e => e.ImageName).HasMaxLength(100);

            });

            

            modelBuilder.Entity<TbIndustrial>(entity =>
            {
                entity.HasKey(e => e.IndustrialId);

                entity.ToTable("TbIndustrial");

                entity.Property(e => e.IndustrialId).HasColumnName("Industrial_Id");

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_Id");

                entity.Property(e => e.SubClaId).HasColumnName("SubCla_Id");

                entity.HasOne(d => d.Purpose)
                    .WithMany(p => p.TbIndustrials)
                    .HasForeignKey(d => d.PurposeId)
                    .HasConstraintName("FK_TbIndustrial_TbPurpose");

                entity.HasOne(d => d.SubCla)
                    .WithMany(p => p.TbIndustrials)
                    .HasForeignKey(d => d.SubClaId)
                    .HasConstraintName("FK_TbIndustrial_TbSubClassification");
            });

            modelBuilder.Entity<TbPurpose>(entity =>
            {
                entity.HasKey(e => e.PurposeId);

                entity.ToTable("TbPurpose");

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_Id");

                entity.Property(e => e.PurposeName).HasMaxLength(30);
            });

            modelBuilder.Entity<TbResidential>(entity =>
            {
                entity.HasKey(e => e.ResidentialId);

                entity.ToTable("TbResidential");

                entity.Property(e => e.ResidentialId).HasColumnName("Residential_Id");

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.FinKitchen).HasColumnName("Fin_Kitchen");

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_Id");

                entity.Property(e => e.SubClaId).HasColumnName("SubCla_Id");

                entity.HasOne(d => d.Purpose)
                    .WithMany(p => p.TbResidentials)
                    .HasForeignKey(d => d.PurposeId)
                    .HasConstraintName("FK_TbResidential_TbPurpose");

                entity.HasOne(d => d.SubCla)
                    .WithMany(p => p.TbResidentials)
                    .HasForeignKey(d => d.SubClaId)
                    .HasConstraintName("FK_TbResidential_TbSubClassification");
            });

            modelBuilder.Entity<TbSubClassification>(entity =>
            {
                entity.HasKey(e => e.SubClaId);

                entity.ToTable("TbSubClassification");

                entity.Property(e => e.SubClaId).HasColumnName("SubCla_Id");

                entity.Property(e => e.ClassificationId).HasColumnName("Classification_Id");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.TbSubClassifications)
                    .HasForeignKey(d => d.ClassificationId)
                    .HasConstraintName("FK_TbSubClassification_TbEstateClassification");
            });

            modelBuilder.Entity<TbTeam>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("TbTeam");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VwAgricultural>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwAgricultural");

                entity.Property(e => e.AgrculturalId).HasColumnName("Agrcultural_Id");

                entity.Property(e => e.Classification).HasMaxLength(30);

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PurposeName).HasMaxLength(30);

                entity.Property(e => e.Types).HasMaxLength(300);
            });

            

            modelBuilder.Entity<VwResidentialHome>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwResidentialHome");

            });

            modelBuilder.Entity<VwIndustrialHome>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwIndustrialHome");

            });

            modelBuilder.Entity<VwCommercialHome>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCommercialHome");

            });

            modelBuilder.Entity<VwAgriculturalHome>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwAgriculturalHome");

            });
            







            modelBuilder.Entity<VwCommercial>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwCommercial");

                entity.Property(e => e.Classification).HasMaxLength(30);

                entity.Property(e => e.CommercialId).HasColumnName("Commercial_Id");

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PurposeName).HasMaxLength(30);
            });

            modelBuilder.Entity<VwIndustrial>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwIndustrial");

                entity.Property(e => e.Classification).HasMaxLength(30);

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.IndustrialId).HasColumnName("Industrial_Id");

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PurposeName).HasMaxLength(30);
            });

            modelBuilder.Entity<VwResidential>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwResidential");

                entity.Property(e => e.Classification).HasMaxLength(30);

                entity.Property(e => e.DateOfPuplish).HasColumnType("date");

                entity.Property(e => e.EstateTitle).HasMaxLength(50);

                entity.Property(e => e.FinKitchen).HasColumnName("Fin_Kitchen");

                entity.Property(e => e.Location).HasMaxLength(700);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.PurposeName).HasMaxLength(30);

                entity.Property(e => e.ResidentialId).HasColumnName("Residential_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
