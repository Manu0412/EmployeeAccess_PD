using EmployeeAccess.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Configurations
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IdentificationNumber).HasMaxLength(20).IsRequired();
            builder.HasIndex(e => e.IdentificationNumber).IsUnique();

            builder.Property(e => e.FirstName).HasMaxLength(64).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(64).IsRequired();

            builder.OwnsOne(e => e.Email, email =>
            {
                email.Property(x => x.Value)
                     .HasColumnName("Email")
                     .HasMaxLength(256)
                     .IsRequired();
            });

            builder.Property(e => e.Position).HasMaxLength(128).IsRequired();
            builder.Property(e => e.Area).HasMaxLength(128).IsRequired();

            builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(16).IsRequired();
            builder.Property(e => e.CreatedAt).IsRequired();
        }
    }
}
