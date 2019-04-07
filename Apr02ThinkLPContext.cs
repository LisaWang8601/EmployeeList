using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeList.Models
{
    public partial class Apr02ThinkLPContext : DbContext
    {
        public Apr02ThinkLPContext()
        {
        }

        public Apr02ThinkLPContext(DbContextOptions<Apr02ThinkLPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.DeptId).HasColumnName("deptId");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("empName")
                    .HasMaxLength(50);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hireDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(30);

                entity.Property(e => e.TerminationDate)
                    .HasColumnName("terminationDate")
                    .HasColumnType("datetime");
            });
        }
    }
}
