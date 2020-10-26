﻿using Hours.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hours.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UsersEntity>
    {
        public void Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(h => h.Id);

            builder.HasIndex(h => h.Email)
                .IsUnique();

            builder.Property(h => h.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.Name)
                 .IsRequired()
                 .HasMaxLength(60);      
        }
    }
}