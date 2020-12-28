using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Entities;

namespace TesteLuby.Data.Mapping
{
    public class DbMappingProject : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(x => x.ID)
                   .HasName("ID");

            builder.Property(x => x.Name)
                   .HasColumnName("Name")
                   .HasColumnType("varchar")
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Date_Start)
                   .HasColumnName("Date_Start")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(x => x.Date_End)
                   .HasColumnName("Date_End")
                   .HasColumnType("datetime")
                   .IsRequired();
        }
    }
}
