using EmployeeAccess.Domain.Entities.AccessControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Persistence.Configurations
{
    internal class AccessPointConfig : IEntityTypeConfiguration<AccessPoint>
    {
        public void Configure(EntityTypeBuilder<AccessPoint> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).HasMaxLength(64).IsRequired();
            builder.HasIndex(a => a.Name).IsUnique();

            builder.Property(a => a.Description).HasMaxLength(512);
            builder.Property(a => a.IsEnabled).IsRequired();
        }
    }
}
