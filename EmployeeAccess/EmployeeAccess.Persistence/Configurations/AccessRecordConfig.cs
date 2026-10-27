using EmployeeAccess.Domain.Entities.AccessControl;
using EmployeeAccess.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Configurations
{
    internal class AccessRecordConfig : IEntityTypeConfiguration<AccessRecord>
    {
        public void Configure(EntityTypeBuilder<AccessRecord> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.CredentialCode).HasMaxLength(64).IsRequired();
            builder.Property(r => r.Movement).HasConversion<string>().HasMaxLength(16).IsRequired();
            builder.Property(r => r.Result).HasConversion<string>().HasMaxLength(16).IsRequired();
            builder.Property(r => r.RejectionReason).HasMaxLength(256);
            builder.Property(r => r.OccurredAt).IsRequired();

            builder.HasOne(r => r.AccessPoint)
                   .WithMany()
                   .HasForeignKey(r => r.AccessPointId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Employee>()
                   .WithMany()
                   .HasForeignKey(r => r.EmployeeId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => r.OccurredAt);
            builder.HasIndex(r => r.EmployeeId);
        }
    }
}
