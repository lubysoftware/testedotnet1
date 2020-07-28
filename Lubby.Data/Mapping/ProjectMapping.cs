using Lubby.Domain.Root;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lubby.Data.Mapping
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property<string>(x => x.Id).HasMaxLength(36).IsRequired();
            builder.Property<string>(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property<DateTime>(x => x.CreationDate);
            builder.Property<DateTime?>(x => x.DetachmentDate);

            builder.ToTable("Project");
        }
    }
}
