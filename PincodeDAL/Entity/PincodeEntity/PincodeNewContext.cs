using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PincodeDAL.Entity.PincodeEntity
{
    public partial class PincodeNewContext : DbContext
    {
        public PincodeNewContext()
        {
        }

        public PincodeNewContext(DbContextOptions<PincodeNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllIndiaPinCode> AllIndiaPinCodes { get; set; } = null!;
        public virtual DbSet<CityMaster> CityMasters { get; set; } = null!;
        public virtual DbSet<DistrictMaster> DistrictMasters { get; set; } = null!;
        public virtual DbSet<MyTable> MyTables { get; set; } = null!;
        public virtual DbSet<StateMaster> StateMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=PincodeNew;Integrated Security=True;Command Timeout=0;Encrypt=False;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<AllIndiaPinCode>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Circlename)
                    .HasMaxLength(255)
                    .HasColumnName("circlename");

                entity.Property(e => e.Deliverystatus).HasMaxLength(255);

                entity.Property(e => e.Districtname).HasMaxLength(255);

                entity.Property(e => e.Divisionname)
                    .HasMaxLength(255)
                    .HasColumnName("divisionname");

                entity.Property(e => e.OfficeType)
                    .HasMaxLength(255)
                    .HasColumnName("officeType");

                entity.Property(e => e.Officename)
                    .HasMaxLength(255)
                    .HasColumnName("officename");

                entity.Property(e => e.Pincode).HasColumnName("pincode");

                entity.Property(e => e.Regionname)
                    .HasMaxLength(255)
                    .HasColumnName("regionname");

                entity.Property(e => e.Statename)
                    .HasMaxLength(255)
                    .HasColumnName("statename");

                entity.Property(e => e.Taluk).HasMaxLength(255);
            });

            modelBuilder.Entity<CityMaster>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("CityMaster");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");
            });

            modelBuilder.Entity<DistrictMaster>(entity =>
            {
                entity.HasKey(e => e.DistrictId);

                entity.ToTable("DistrictMaster");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");
            });

            modelBuilder.Entity<MyTable>(entity =>
            {
                entity.ToTable("my_table");

                entity.Property(e => e.Active)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hobby)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("StateMaster");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.StateCode).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
