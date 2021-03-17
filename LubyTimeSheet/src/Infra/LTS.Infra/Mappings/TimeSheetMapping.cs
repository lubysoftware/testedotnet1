using LTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LTS.Infra.Mappings
{
    public class TimeSheetMapping : IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(n => n.DateBegin).IsRequired();
            builder.Property(a => a.DateEnd).IsRequired();
            builder.Property(x => x.TotalHours).IsRequired();

            builder.HasOne(x => x.Developer).WithMany(y => y.TimeSheets).HasForeignKey(x => x.DevelopeId);
            builder.HasOne(x => x.Project).WithMany(y => y.TimeSheets).HasForeignKey(x => x.ProjectId);
        }
    }
}
