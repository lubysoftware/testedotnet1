﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeManager.Domain.Developers.TimeReports;

namespace TimeManager.Infrastructure.Persistence.Mapping
{
    public class TimeReportMapping : IEntityTypeConfiguration<TimeReport>
    {
        public void Configure(EntityTypeBuilder<TimeReport> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(c => c.StartedAt)
                .IsRequired();

            builder
                .Property(c => c.EndedAt)
                .IsRequired();

            builder
                .Property(c => c.CalculatedHoursWorked)
                .IsRequired();

            builder
                .Property(c => c.CalculatedWeekOfTheYear)
                .IsRequired();

            builder
                .Property(c => c.WeekDay)
                .IsRequired();

             builder
                .HasOne(c => c.Developer)
                .WithMany(c => c.TimeReports)
                .HasForeignKey(c => c.DeveloperId);

            builder
                .HasOne(d => d.Project)
                .WithMany(m => m.TimeReports)
                .HasForeignKey(k => k.ProjectId);
        }
    }
}
