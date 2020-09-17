using LubyClocker.Domain.BoundedContexts.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubyClocker.Infra.Data.Mappings
{
    public class TimeEntryMap : BaseEntityMap<TimeEntry>
    {
        protected override void ConfigureMap(EntityTypeBuilder<TimeEntry> builder)
        {
            builder
                .Property(c => c.Start);
            
            builder
                .Property(c => c.End);
            
            builder
                .Property(e => e.WorkedTime);
            
            builder
                .HasOne(c => c.ProjectMember)
                .WithMany(c => c.TimeEntries)
                .HasForeignKey(c => c.ProjectMemberId);
        }
    }
}