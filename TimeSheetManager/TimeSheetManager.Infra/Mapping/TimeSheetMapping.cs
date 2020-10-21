using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheetManager.Domain.Entities.TimeSheetNS;

namespace TimeSheetManager.Infra.Mapping
{
    public class TimeSheetMapping : IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Developer)
                   .WithMany(x => x.WorkTime)
                   .HasForeignKey(x => x.DevId);

            builder.Property(x => x.EntryTime)
                   .IsRequired();

            builder.Property(x => x.ExitTime)
                   .IsRequired();

            builder.Property(x => x.TotalHours)
                   .IsRequired();

            builder.Property(x => x.WeekId)
                   .IsRequired();

        }
    }
}