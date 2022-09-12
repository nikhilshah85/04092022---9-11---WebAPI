using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DI_Demo.Models.EF
{
    public partial class bankingDBAPIContext : DbContext
    {
        public bankingDBAPIContext()
        {
        }

        public bankingDBAPIContext(DbContextOptions<bankingDBAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountsInfo> AccountsInfos { get; set; } = null!;
        public virtual DbSet<BranchInfo> BranchInfos { get; set; } = null!;
        public virtual DbSet<TransactionInfo> TransactionInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=WIN8\\NIKHILINSTANCE;database=bankingDBAPI; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsInfo>(entity =>
            {
                entity.HasKey(e => e.AccNo)
                    .HasName("PK__accounts__A4719705FF1AB5D7");

                entity.ToTable("accountsInfo");

                entity.Property(e => e.AccNo)
                    .ValueGeneratedNever()
                    .HasColumnName("accNo");

                entity.Property(e => e.AccBalance).HasColumnName("accBalance");

                entity.Property(e => e.AccBranch).HasColumnName("accBranch");

                entity.Property(e => e.AccName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("accName");

                entity.Property(e => e.AccType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("accType");

                entity.HasOne(d => d.AccBranchNavigation)
                    .WithMany(p => p.AccountsInfos)
                    .HasForeignKey(d => d.AccBranch)
                    .HasConstraintName("fk_accBranch");
            });

            modelBuilder.Entity<BranchInfo>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__branchIn__751EBD5F6CD12A72");

                entity.ToTable("branchInfo");

                entity.Property(e => e.BranchId)
                    .ValueGeneratedNever()
                    .HasColumnName("branchId");

                entity.Property(e => e.BranchCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branchCity");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branchName");
            });

            modelBuilder.Entity<TransactionInfo>(entity =>
            {
                entity.HasKey(e => e.TrId)
                    .HasName("PK__transact__9C31E3922F634BCB");

                entity.ToTable("transactionInfo");

                entity.Property(e => e.TrId).HasColumnName("trId");

                entity.Property(e => e.AccNoFrom).HasColumnName("accNoFrom");

                entity.Property(e => e.AccNoTo).HasColumnName("accNoTo");

                entity.Property(e => e.BranchNo).HasColumnName("branchNo");

                entity.Property(e => e.TrAmount).HasColumnName("trAmount");

                entity.Property(e => e.TrDate)
                    .HasColumnType("date")
                    .HasColumnName("trDate");

                entity.HasOne(d => d.AccNoFromNavigation)
                    .WithMany(p => p.TransactionInfoAccNoFromNavigations)
                    .HasForeignKey(d => d.AccNoFrom)
                    .HasConstraintName("fk_accNoFrom");

                entity.HasOne(d => d.AccNoToNavigation)
                    .WithMany(p => p.TransactionInfoAccNoToNavigations)
                    .HasForeignKey(d => d.AccNoTo)
                    .HasConstraintName("fk_accNoTo");

                entity.HasOne(d => d.BranchNoNavigation)
                    .WithMany(p => p.TransactionInfos)
                    .HasForeignKey(d => d.BranchNo)
                    .HasConstraintName("fk_branchNo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
