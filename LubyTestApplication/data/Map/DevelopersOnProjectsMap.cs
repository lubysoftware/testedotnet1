using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using test.domain.Entities;

namespace test.data.Map
{
    public class DevelopersOnProjectsMap : IEntityTypeConfiguration<DeveloperOnProject>
    {
        public void Configure(EntityTypeBuilder<DeveloperOnProject> builder)
        {
            builder.ToTable("DeveloperOnProject");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.DeveloperId).HasColumnName("Fk_Developer");
            builder.Property(c => c.ProjectId).HasColumnName("Fk_Project");

            builder.HasOne(c => c.Developer)
                .WithMany(c => c.DeveloperOnProject)
                .HasForeignKey(c => c.DeveloperId);

            builder.HasOne(c => c.Project)
                 .WithMany(c => c.DeveloperOnProject)
                 .HasForeignKey(c => c.ProjectId);
        }
    }
}
