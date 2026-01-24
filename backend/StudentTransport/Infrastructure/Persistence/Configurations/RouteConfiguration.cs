using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.StartPoint)
                   .IsRequired();

            builder.Property(r => r.EndPoint)
                   .IsRequired();
        }
    }
}
