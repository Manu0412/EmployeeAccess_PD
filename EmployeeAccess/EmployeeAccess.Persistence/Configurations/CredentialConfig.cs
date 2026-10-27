using EmployeeAccess.Domain.Entities.Credentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Configurations
{
    internal class CredentialConfig : IEntityTypeConfiguration<Credential>
    {
        public void Configure(EntityTypeBuilder<Credential> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code).HasMaxLength(64).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.Property(c => c.Status).HasConversion<string>().HasMaxLength(16).IsRequired();
            builder.Property(c => c.IssuedAt).IsRequired();

            builder.HasOne(c => c.Employee)
                   .WithMany()
                   .HasForeignKey(c => c.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
