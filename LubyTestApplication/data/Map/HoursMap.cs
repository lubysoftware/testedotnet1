using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using test.domain.Entities;

namespace test.data.Map
{
    public class HoursMap : IEntityTypeConfiguration<Hours>
    {
        public void Configure(EntityTypeBuilder<Hours> builder)
        {
            builder.ToTable("Hours");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.EndDate);
            builder.Property(c => c.StartDate);
            builder.Property(c => c.Developer);

            //builder.HasOne(c => c.Developer)
            //    .WithMany(c => c.Hours);

        }
    }
}
