using Lubby.Domain.Root;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lubby.Data.Mapping
{
    public class WorkMapping : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.WorkId);
            builder.Property<string>(x => x.WorkId).HasMaxLength(36).IsRequired();
            builder.HasOne<Project>(x => x.Project);
            builder.HasOne<Developer>(x => x.Dev);
            builder.Property<DateTime>(x => x.StartDate);
            builder.Property<DateTime?>(x => x.EndDate);

            builder.ToTable("Work");
        }
    }
}
