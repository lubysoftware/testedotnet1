using Microsoft.EntityFrameworkCore;
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
                .HasOne(c => c.ProjectMember)
                .WithMany(c => c.TimeReports)
                .HasForeignKey(c => c.ProjectMemberId);
        }
    }
}
