using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(u => u.ShippingAddress);
        builder.OwnsOne(p => p.HomeAddress);

        builder.Property(p => p.Id).HasColumnName("UserId");

        builder
            .Property(p => p.Name)
            .HasMaxLength(40);
    }
}
