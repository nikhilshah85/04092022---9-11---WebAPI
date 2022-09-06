using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace shoppingWebAPI_EF.Models.EF
{
    public partial class shoppingAPIDBContext : DbContext
    {
        public shoppingAPIDBContext()
        {
        }

        public shoppingAPIDBContext(DbContextOptions<shoppingAPIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=WIN8\\NIKHILINSTANCE; database=shoppingAPIDB;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Customer__D830D4772BB5B264");

                entity.Property(e => e.CId)
                    .ValueGeneratedNever()
                    .HasColumnName("cId");

                entity.Property(e => e.CCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCategory");

                entity.Property(e => e.CIsActive).HasColumnName("cIsActive");

                entity.Property(e => e.CLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cLocation");

                entity.Property(e => e.CName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cName");

                entity.Property(e => e.CWallet).HasColumnName("cWallet");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Products__DD36D5627EF1C570");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("pId");

                entity.Property(e => e.PCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pCategory");

                entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");

                entity.Property(e => e.PName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pName");

                entity.Property(e => e.PPrice).HasColumnName("pPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
