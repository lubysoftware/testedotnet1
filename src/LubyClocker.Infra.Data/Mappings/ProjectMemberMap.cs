using LubyClocker.Domain.BoundedContexts.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LubyClocker.Infra.Data.Mappings
{
    public class ProjectMemberMap : BaseEntityMap<ProjectMember>
    {
        protected override void ConfigureMap(EntityTypeBuilder<ProjectMember> builder)
        {
            builder
                .Property(c => c.EntryDate);

            builder
                .HasOne(c => c.Developer)
                .WithMany(c => c.Projects)
                .HasForeignKey(c => c.DeveloperId);
            
            builder
                .HasOne(c => c.Project)
                .WithMany(c => c.Members)
                .HasForeignKey(c => c.ProjectId);
        }
    }
}