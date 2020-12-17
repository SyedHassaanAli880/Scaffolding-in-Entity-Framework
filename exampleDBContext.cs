using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scaffolding.Models
{
    public partial class exampleDBContext : DbContext
    {
        public exampleDBContext()
        {
        }

        public exampleDBContext(DbContextOptions<exampleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QEVD9D5;Initial Catalog=exampleDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StuId)
                    .HasName("PK__students__E53CAB21EDE56251");

                entity.ToTable("students");

                entity.HasIndex(e => e.StuEmail)
                    .HasName("UQ__students__103452DF3476FB2D")
                    .IsUnique();

                entity.Property(e => e.StuId).HasColumnName("stu_id");

                entity.Property(e => e.StuCity)
                    .IsRequired()
                    .HasColumnName("stu_city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StuEmail)
                    .IsRequired()
                    .HasColumnName("stu_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StuName)
                    .IsRequired()
                    .HasColumnName("stu_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StuPhone)
                    .IsRequired()
                    .HasColumnName("stu_phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

