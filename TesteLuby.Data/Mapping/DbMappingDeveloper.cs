using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Entities;

namespace TesteLuby.Data.Mapping
{
    public class DbMappingDeveloper : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developers");

            builder.HasKey(x => x.ID)
                   .HasName("ID");

            builder.Property(x => x.Name)
                   .HasColumnName("Name")
                   .HasColumnType("varchar")
                   .HasMaxLength(150);
        }
    }
}
